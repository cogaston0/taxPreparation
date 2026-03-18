<?php

declare(strict_types=1);

namespace TaxPreparation;

/**
 * Tax Preparation Agent for Target.com
 *
 * Orchestrates the tax preparation process: collects tax form data,
 * runs calculations, and produces a summary report with the amount
 * owed or the refund due.
 */
class TaxAgent
{
    private TaxCalculator $calculator;
    private array $log = [];

    public function __construct(?TaxCalculator $calculator = null)
    {
        $this->calculator = $calculator ?? new TaxCalculator();
    }

    /**
     * Process a TaxForm and return a structured result array containing:
     *  - filer_id
     *  - tax_year
     *  - filing_status
     *  - total_income
     *  - effective_deduction
     *  - taxable_income
     *  - federal_tax_owed
     *  - state_tax_owed
     *  - total_tax_owed
     *  - federal_tax_withheld
     *  - state_tax_withheld
     *  - total_withheld
     *  - federal_refund_or_owed  (positive = refund, negative = owed)
     *  - state_refund_or_owed    (positive = refund, negative = owed)
     *  - net_refund_or_owed      (positive = total refund, negative = total owed)
     *  - notes
     *  - log
     */
    public function prepare(TaxForm $form): array
    {
        $this->log = [];
        $this->logStep("Starting tax preparation for filer: {$form->getFilerId()} (tax year {$form->getTaxYear()})");

        $totalIncome = $form->getTotalIncome();
        $this->logStep("Total income: \${$totalIncome}");

        $effectiveDeduction = $this->calculator->getEffectiveDeduction(
            $form->getFilingStatus(),
            $form->getDeductions()
        );
        $this->logStep("Effective deduction (standard vs. itemized): \${$effectiveDeduction}");

        $taxableIncome = max(0.0, $totalIncome - $effectiveDeduction);
        $this->logStep("Taxable income: \${$taxableIncome}");

        $federalTaxOwed = $this->calculator->calculateFederalTax($taxableIncome, $form->getFilingStatus());
        $this->logStep("Federal tax owed: \${$federalTaxOwed}");

        $stateTaxOwed = $this->calculator->calculateStateTax($taxableIncome);
        $this->logStep("State tax owed: \${$stateTaxOwed}");

        $totalTaxOwed = round($federalTaxOwed + $stateTaxOwed, 2);

        $federalWithheld = $form->getFederalTaxWithheld();
        $stateWithheld = $form->getStateTaxWithheld();
        $totalWithheld = round($federalWithheld + $stateWithheld, 2);

        $federalBalance = round($federalWithheld - $federalTaxOwed, 2);
        $stateBalance = round($stateWithheld - $stateTaxOwed, 2);
        $netBalance = round($totalWithheld - $totalTaxOwed, 2);

        if ($netBalance >= 0) {
            $this->logStep("Result: REFUND of \${$netBalance}");
        } else {
            $amountOwed = abs($netBalance);
            $this->logStep("Result: AMOUNT OWED of \${$amountOwed}");
        }

        return [
            'filer_id'             => $form->getFilerId(),
            'tax_year'             => $form->getTaxYear(),
            'filing_status'        => $form->getFilingStatus(),
            'total_income'         => $totalIncome,
            'effective_deduction'  => $effectiveDeduction,
            'taxable_income'       => $taxableIncome,
            'federal_tax_owed'     => $federalTaxOwed,
            'state_tax_owed'       => $stateTaxOwed,
            'total_tax_owed'       => $totalTaxOwed,
            'federal_tax_withheld' => $federalWithheld,
            'state_tax_withheld'   => $stateWithheld,
            'total_withheld'       => $totalWithheld,
            'federal_refund_or_owed' => $federalBalance,
            'state_refund_or_owed'   => $stateBalance,
            'net_refund_or_owed'     => $netBalance,
            'notes'                => $form->getNotes(),
            'log'                  => $this->log,
        ];
    }

    /**
     * Format a preparation result as a human-readable summary string.
     */
    public function formatSummary(array $result): string
    {
        $lines = [];
        $lines[] = "=== Tax Preparation Summary ===";
        $lines[] = "Filer ID    : {$result['filer_id']}";
        $lines[] = "Tax Year    : {$result['tax_year']}";
        $lines[] = "Filing Status: " . str_replace('_', ' ', ucfirst($result['filing_status']));
        $lines[] = "";
        $lines[] = "--- Income ---";
        $lines[] = "Total Income       : \$" . number_format($result['total_income'], 2);
        $lines[] = "Effective Deduction: \$" . number_format($result['effective_deduction'], 2);
        $lines[] = "Taxable Income     : \$" . number_format($result['taxable_income'], 2);
        $lines[] = "";
        $lines[] = "--- Tax Calculation ---";
        $lines[] = "Federal Tax Owed   : \$" . number_format($result['federal_tax_owed'], 2);
        $lines[] = "State Tax Owed     : \$" . number_format($result['state_tax_owed'], 2);
        $lines[] = "Total Tax Owed     : \$" . number_format($result['total_tax_owed'], 2);
        $lines[] = "";
        $lines[] = "--- Withholding ---";
        $lines[] = "Federal Withheld   : \$" . number_format($result['federal_tax_withheld'], 2);
        $lines[] = "State Withheld     : \$" . number_format($result['state_tax_withheld'], 2);
        $lines[] = "Total Withheld     : \$" . number_format($result['total_withheld'], 2);
        $lines[] = "";
        $lines[] = "--- Result ---";

        $net = $result['net_refund_or_owed'];
        if ($net >= 0) {
            $lines[] = "*** REFUND: \$" . number_format($net, 2) . " ***";
        } else {
            $lines[] = "*** AMOUNT DUE: \$" . number_format(abs($net), 2) . " ***";
        }

        if (!empty($result['notes'])) {
            $lines[] = "";
            $lines[] = "--- Notes ---";
            foreach ($result['notes'] as $note) {
                $lines[] = "  - {$note}";
            }
        }

        return implode("\n", $lines);
    }

    private function logStep(string $message): void
    {
        $this->log[] = $message;
    }
}
