#!/usr/bin/env php
<?php

declare(strict_types=1);

require_once __DIR__ . '/vendor/autoload.php';

use TaxPreparation\TaxAgent;
use TaxPreparation\TaxForm;

/**
 * Tax Preparation Agent — Command-Line Entry Point
 * For Target.com
 *
 * Usage: php index.php
 */

$agent = new TaxAgent();

// Example: Single filer with one W-2 from Target Corporation
$form = new TaxForm(
    filerId: 'TARGET-EMP-001',
    filingStatus: 'single',
    taxYear: 2024
);

$form->addW2([
    'employer'            => 'Target Corporation',
    'wages'               => 52000.00,
    'federal_tax_withheld' => 6240.00,
    'state_tax_withheld'  => 2080.00,
]);

$form->setOtherIncome(1200.00);   // e.g., bank interest
$form->setDeductions(0.0);        // will use standard deduction
$form->addNote("Employee discount purchases are not taxable income.");
$form->addNote("Check eligibility for Earned Income Credit if applicable.");

$result = $agent->prepare($form);
echo $agent->formatSummary($result) . "\n";
