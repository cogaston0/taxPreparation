<?php

declare(strict_types=1);

namespace TaxPreparation;

/**
 * Represents a tax form with filer information, income, and deductions.
 */
class TaxForm
{
    private string $filerId;
    private string $filingStatus;
    private int $taxYear;
    private float $wages = 0.0;
    private float $otherIncome = 0.0;
    private float $federalTaxWithheld = 0.0;
    private float $stateTaxWithheld = 0.0;
    private float $deductions = 0.0;
    private array $w2Forms = [];
    private array $notes = [];

    private const VALID_FILING_STATUSES = [
        'single',
        'married_filing_jointly',
        'married_filing_separately',
        'head_of_household',
        'qualifying_surviving_spouse',
    ];

    public function __construct(string $filerId, string $filingStatus, int $taxYear)
    {
        if (!in_array($filingStatus, self::VALID_FILING_STATUSES, true)) {
            throw new \InvalidArgumentException(
                "Invalid filing status: '{$filingStatus}'. Valid statuses are: "
                . implode(', ', self::VALID_FILING_STATUSES)
            );
        }

        if ($taxYear < 2000 || $taxYear > (int) date('Y')) {
            throw new \InvalidArgumentException("Tax year must be between 2000 and the current year.");
        }

        $this->filerId = $filerId;
        $this->filingStatus = $filingStatus;
        $this->taxYear = $taxYear;
    }

    public function addW2(array $w2Data): void
    {
        $required = ['employer', 'wages', 'federal_tax_withheld', 'state_tax_withheld'];
        foreach ($required as $field) {
            if (!isset($w2Data[$field])) {
                throw new \InvalidArgumentException("W-2 form is missing required field: '{$field}'");
            }
        }

        $this->w2Forms[] = $w2Data;
        $this->wages += (float) $w2Data['wages'];
        $this->federalTaxWithheld += (float) $w2Data['federal_tax_withheld'];
        $this->stateTaxWithheld += (float) $w2Data['state_tax_withheld'];
    }

    public function setOtherIncome(float $amount): void
    {
        if ($amount < 0) {
            throw new \InvalidArgumentException("Other income cannot be negative.");
        }
        $this->otherIncome = $amount;
    }

    public function setDeductions(float $amount): void
    {
        if ($amount < 0) {
            throw new \InvalidArgumentException("Deductions cannot be negative.");
        }
        $this->deductions = $amount;
    }

    public function addNote(string $note): void
    {
        $this->notes[] = $note;
    }

    public function getFilerId(): string
    {
        return $this->filerId;
    }

    public function getFilingStatus(): string
    {
        return $this->filingStatus;
    }

    public function getTaxYear(): int
    {
        return $this->taxYear;
    }

    public function getWages(): float
    {
        return $this->wages;
    }

    public function getOtherIncome(): float
    {
        return $this->otherIncome;
    }

    public function getTotalIncome(): float
    {
        return $this->wages + $this->otherIncome;
    }

    public function getFederalTaxWithheld(): float
    {
        return $this->federalTaxWithheld;
    }

    public function getStateTaxWithheld(): float
    {
        return $this->stateTaxWithheld;
    }

    public function getDeductions(): float
    {
        return $this->deductions;
    }

    public function getW2Forms(): array
    {
        return $this->w2Forms;
    }

    public function getNotes(): array
    {
        return $this->notes;
    }
}
