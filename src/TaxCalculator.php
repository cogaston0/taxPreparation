<?php

declare(strict_types=1);

namespace TaxPreparation;

/**
 * Performs federal and state tax calculations based on IRS tax brackets.
 */
class TaxCalculator
{
    /**
     * 2024 federal income tax brackets (taxable income → rate).
     * Source: IRS Revenue Procedure 2023-34
     */
    private const FEDERAL_BRACKETS = [
        'single' => [
            [0, 11600, 0.10],
            [11600, 47150, 0.12],
            [47150, 100525, 0.22],
            [100525, 191950, 0.24],
            [191950, 243725, 0.32],
            [243725, 609350, 0.35],
            [609350, PHP_INT_MAX, 0.37],
        ],
        'married_filing_jointly' => [
            [0, 23200, 0.10],
            [23200, 94300, 0.12],
            [94300, 201050, 0.22],
            [201050, 383900, 0.24],
            [383900, 487450, 0.32],
            [487450, 731200, 0.35],
            [731200, PHP_INT_MAX, 0.37],
        ],
        'married_filing_separately' => [
            [0, 11600, 0.10],
            [11600, 47150, 0.12],
            [47150, 100525, 0.22],
            [100525, 191950, 0.24],
            [191950, 243725, 0.32],
            [243725, 365600, 0.35],
            [365600, PHP_INT_MAX, 0.37],
        ],
        'head_of_household' => [
            [0, 16550, 0.10],
            [16550, 63100, 0.12],
            [63100, 100500, 0.22],
            [100500, 191950, 0.24],
            [191950, 243700, 0.32],
            [243700, 609350, 0.35],
            [609350, PHP_INT_MAX, 0.37],
        ],
        'qualifying_surviving_spouse' => [
            [0, 23200, 0.10],
            [23200, 94300, 0.12],
            [94300, 201050, 0.22],
            [201050, 383900, 0.24],
            [383900, 487450, 0.32],
            [487450, 731200, 0.35],
            [731200, PHP_INT_MAX, 0.37],
        ],
    ];

    /**
     * 2024 standard deduction amounts by filing status.
     */
    private const STANDARD_DEDUCTIONS = [
        'single'                      => 14600.0,
        'married_filing_jointly'      => 29200.0,
        'married_filing_separately'   => 14600.0,
        'head_of_household'           => 21900.0,
        'qualifying_surviving_spouse' => 29200.0,
    ];

    /**
     * Flat state income tax rate (approximation; actual rates vary by state).
     */
    private const STATE_TAX_RATE = 0.05;

    /**
     * Calculate federal tax owed based on taxable income and filing status.
     */
    public function calculateFederalTax(float $taxableIncome, string $filingStatus): float
    {
        if ($taxableIncome <= 0) {
            return 0.0;
        }

        $brackets = self::FEDERAL_BRACKETS[$filingStatus]
            ?? throw new \InvalidArgumentException("Unknown filing status: '{$filingStatus}'");

        $tax = 0.0;
        foreach ($brackets as [$lower, $upper, $rate]) {
            if ($taxableIncome <= $lower) {
                break;
            }
            $taxable = min($taxableIncome, $upper) - $lower;
            $tax += $taxable * $rate;
        }

        return round($tax, 2);
    }

    /**
     * Calculate state tax owed based on taxable income.
     */
    public function calculateStateTax(float $taxableIncome): float
    {
        if ($taxableIncome <= 0) {
            return 0.0;
        }
        return round($taxableIncome * self::STATE_TAX_RATE, 2);
    }

    /**
     * Get the standard deduction for a given filing status.
     */
    public function getStandardDeduction(string $filingStatus): float
    {
        return self::STANDARD_DEDUCTIONS[$filingStatus]
            ?? throw new \InvalidArgumentException("Unknown filing status: '{$filingStatus}'");
    }

    /**
     * Determine the effective deduction (larger of standard vs. itemized).
     */
    public function getEffectiveDeduction(string $filingStatus, float $itemizedDeductions): float
    {
        $standardDeduction = $this->getStandardDeduction($filingStatus);
        return max($standardDeduction, $itemizedDeductions);
    }
}
