<?php

declare(strict_types=1);

namespace TaxPreparation\Tests;

use PHPUnit\Framework\TestCase;
use TaxPreparation\TaxAgent;
use TaxPreparation\TaxCalculator;
use TaxPreparation\TaxForm;

class TaxAgentTest extends TestCase
{
    private TaxAgent $agent;
    private TaxCalculator $calculator;

    protected function setUp(): void
    {
        $this->calculator = new TaxCalculator();
        $this->agent = new TaxAgent($this->calculator);
    }

    // ---- TaxForm tests ----

    public function testTaxFormCreation(): void
    {
        $form = new TaxForm('USR-001', 'single', 2024);
        $this->assertSame('USR-001', $form->getFilerId());
        $this->assertSame('single', $form->getFilingStatus());
        $this->assertSame(2024, $form->getTaxYear());
    }

    public function testTaxFormInvalidFilingStatus(): void
    {
        $this->expectException(\InvalidArgumentException::class);
        new TaxForm('USR-001', 'unknown_status', 2024);
    }

    public function testTaxFormInvalidTaxYear(): void
    {
        $this->expectException(\InvalidArgumentException::class);
        new TaxForm('USR-001', 'single', 1999);
    }

    public function testAddW2AccumulatesWages(): void
    {
        $form = new TaxForm('USR-001', 'single', 2024);
        $form->addW2([
            'employer'             => 'Target Corporation',
            'wages'                => 40000.0,
            'federal_tax_withheld' => 4000.0,
            'state_tax_withheld'   => 1200.0,
        ]);
        $form->addW2([
            'employer'             => 'Part-time employer',
            'wages'                => 10000.0,
            'federal_tax_withheld' => 1000.0,
            'state_tax_withheld'   => 300.0,
        ]);

        $this->assertSame(50000.0, $form->getWages());
        $this->assertSame(5000.0, $form->getFederalTaxWithheld());
        $this->assertSame(1500.0, $form->getStateTaxWithheld());
        $this->assertCount(2, $form->getW2Forms());
    }

    public function testAddW2MissingFieldThrows(): void
    {
        $this->expectException(\InvalidArgumentException::class);
        $form = new TaxForm('USR-001', 'single', 2024);
        $form->addW2(['employer' => 'Target', 'wages' => 50000.0]);
    }

    public function testNegativeOtherIncomeThrows(): void
    {
        $this->expectException(\InvalidArgumentException::class);
        $form = new TaxForm('USR-001', 'single', 2024);
        $form->setOtherIncome(-100.0);
    }

    public function testNegativeDeductionsThrow(): void
    {
        $this->expectException(\InvalidArgumentException::class);
        $form = new TaxForm('USR-001', 'single', 2024);
        $form->setDeductions(-500.0);
    }

    public function testTotalIncome(): void
    {
        $form = new TaxForm('USR-001', 'single', 2024);
        $form->addW2([
            'employer'             => 'Target',
            'wages'                => 60000.0,
            'federal_tax_withheld' => 6000.0,
            'state_tax_withheld'   => 2000.0,
        ]);
        $form->setOtherIncome(5000.0);
        $this->assertSame(65000.0, $form->getTotalIncome());
    }

    // ---- TaxCalculator tests ----

    public function testStandardDeductionSingle(): void
    {
        $this->assertSame(14600.0, $this->calculator->getStandardDeduction('single'));
    }

    public function testStandardDeductionMarriedJointly(): void
    {
        $this->assertSame(29200.0, $this->calculator->getStandardDeduction('married_filing_jointly'));
    }

    public function testEffectiveDeductionUsesLarger(): void
    {
        // Itemized higher than standard
        $effective = $this->calculator->getEffectiveDeduction('single', 20000.0);
        $this->assertSame(20000.0, $effective);

        // Standard higher than itemized
        $effective = $this->calculator->getEffectiveDeduction('single', 5000.0);
        $this->assertSame(14600.0, $effective);
    }

    public function testFederalTaxZeroIncome(): void
    {
        $this->assertSame(0.0, $this->calculator->calculateFederalTax(0.0, 'single'));
    }

    public function testFederalTaxNegativeIncome(): void
    {
        $this->assertSame(0.0, $this->calculator->calculateFederalTax(-100.0, 'single'));
    }

    public function testFederalTaxSingleBracket(): void
    {
        // $10,000 taxable income is in the 10% bracket (< $11,600)
        $tax = $this->calculator->calculateFederalTax(10000.0, 'single');
        $this->assertSame(1000.0, $tax);
    }

    public function testFederalTaxSingleMultiBracket(): void
    {
        // $50,000 taxable income spans 10%, 12%, and 22% brackets
        // 10%: $11,600 × 0.10 = $1,160
        // 12%: ($47,150 - $11,600) × 0.12 = $4,266
        // 22%: ($50,000 - $47,150) × 0.22 = $627
        // Total = $6,053
        $tax = $this->calculator->calculateFederalTax(50000.0, 'single');
        $this->assertSame(6053.0, $tax);
    }

    public function testStateTaxCalculation(): void
    {
        $tax = $this->calculator->calculateStateTax(40000.0);
        $this->assertSame(2000.0, $tax);
    }

    public function testStateTaxZeroIncome(): void
    {
        $this->assertSame(0.0, $this->calculator->calculateStateTax(0.0));
    }

    public function testInvalidFilingStatusThrowsInCalculator(): void
    {
        $this->expectException(\InvalidArgumentException::class);
        $this->calculator->calculateFederalTax(50000.0, 'invalid_status');
    }

    // ---- TaxAgent integration tests ----

    public function testAgentPrepareProducesExpectedKeys(): void
    {
        $form = new TaxForm('TARGET-001', 'single', 2024);
        $form->addW2([
            'employer'             => 'Target Corporation',
            'wages'                => 52000.0,
            'federal_tax_withheld' => 6240.0,
            'state_tax_withheld'   => 2080.0,
        ]);

        $result = $this->agent->prepare($form);

        $expectedKeys = [
            'filer_id', 'tax_year', 'filing_status', 'total_income',
            'effective_deduction', 'taxable_income', 'federal_tax_owed',
            'state_tax_owed', 'total_tax_owed', 'federal_tax_withheld',
            'state_tax_withheld', 'total_withheld',
            'federal_refund_or_owed', 'state_refund_or_owed', 'net_refund_or_owed',
            'notes', 'log',
        ];

        foreach ($expectedKeys as $key) {
            $this->assertArrayHasKey($key, $result, "Result is missing key: '{$key}'");
        }
    }

    public function testAgentPrepareRefund(): void
    {
        $form = new TaxForm('TARGET-001', 'single', 2024);
        $form->addW2([
            'employer'             => 'Target Corporation',
            'wages'                => 30000.0,
            'federal_tax_withheld' => 5000.0,   // over-withheld
            'state_tax_withheld'   => 1500.0,
        ]);

        $result = $this->agent->prepare($form);

        // Taxable income = 30000 - 14600 (standard) = 15400
        $this->assertSame(15400.0, $result['taxable_income']);

        // Federal tax = 11600×0.10 + (15400-11600)×0.12 = 1160 + 456 = 1616
        $this->assertSame(1616.0, $result['federal_tax_owed']);

        // Should get a refund since withheld > owed
        $this->assertGreaterThan(0, $result['net_refund_or_owed']);
    }

    public function testAgentPrepareAmountOwed(): void
    {
        $form = new TaxForm('TARGET-002', 'single', 2024);
        $form->addW2([
            'employer'             => 'Target Corporation',
            'wages'                => 80000.0,
            'federal_tax_withheld' => 100.0,    // under-withheld
            'state_tax_withheld'   => 50.0,
        ]);

        $result = $this->agent->prepare($form);

        // Should owe money
        $this->assertLessThan(0, $result['net_refund_or_owed']);
    }

    public function testAgentPrepareWithItemizedDeductions(): void
    {
        $form = new TaxForm('TARGET-003', 'single', 2024);
        $form->addW2([
            'employer'             => 'Target Corporation',
            'wages'                => 100000.0,
            'federal_tax_withheld' => 15000.0,
            'state_tax_withheld'   => 4000.0,
        ]);
        $form->setDeductions(25000.0);  // higher than standard $14,600

        $result = $this->agent->prepare($form);

        $this->assertSame(25000.0, $result['effective_deduction']);
        $this->assertSame(75000.0, $result['taxable_income']);
    }

    public function testAgentFormatSummaryContainsRefund(): void
    {
        $form = new TaxForm('TARGET-001', 'single', 2024);
        $form->addW2([
            'employer'             => 'Target Corporation',
            'wages'                => 30000.0,
            'federal_tax_withheld' => 5000.0,
            'state_tax_withheld'   => 1500.0,
        ]);

        $result = $this->agent->prepare($form);
        $summary = $this->agent->formatSummary($result);

        $this->assertStringContainsString('REFUND', $summary);
        $this->assertStringContainsString('TARGET-001', $summary);
        $this->assertStringContainsString('2024', $summary);
    }

    public function testAgentFormatSummaryContainsAmountDue(): void
    {
        $form = new TaxForm('TARGET-002', 'single', 2024);
        $form->addW2([
            'employer'             => 'Target Corporation',
            'wages'                => 80000.0,
            'federal_tax_withheld' => 100.0,
            'state_tax_withheld'   => 50.0,
        ]);

        $result = $this->agent->prepare($form);
        $summary = $this->agent->formatSummary($result);

        $this->assertStringContainsString('AMOUNT DUE', $summary);
    }

    public function testAgentNotesIncludedInResult(): void
    {
        $form = new TaxForm('TARGET-001', 'single', 2024);
        $form->addW2([
            'employer'             => 'Target Corporation',
            'wages'                => 50000.0,
            'federal_tax_withheld' => 5000.0,
            'state_tax_withheld'   => 2000.0,
        ]);
        $form->addNote("Check Earned Income Credit eligibility.");
        $form->addNote("Verify 401(k) contributions.");

        $result = $this->agent->prepare($form);

        $this->assertCount(2, $result['notes']);
        $this->assertStringContainsString('Earned Income Credit', $result['notes'][0]);
    }

    public function testAgentLogIsPopulated(): void
    {
        $form = new TaxForm('TARGET-001', 'single', 2024);
        $form->addW2([
            'employer'             => 'Target Corporation',
            'wages'                => 50000.0,
            'federal_tax_withheld' => 5000.0,
            'state_tax_withheld'   => 2000.0,
        ]);

        $result = $this->agent->prepare($form);

        $this->assertNotEmpty($result['log']);
    }

    public function testAgentMarriedFilingJointly(): void
    {
        $form = new TaxForm('TARGET-004', 'married_filing_jointly', 2024);
        $form->addW2([
            'employer'             => 'Target Corporation',
            'wages'                => 100000.0,
            'federal_tax_withheld' => 10000.0,
            'state_tax_withheld'   => 3000.0,
        ]);

        $result = $this->agent->prepare($form);

        // Standard deduction for MFJ is $29,200
        $this->assertSame(29200.0, $result['effective_deduction']);
        $this->assertSame(70800.0, $result['taxable_income']);
    }
}
