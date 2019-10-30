using System;

namespace RefactoringGolf.hole05
{
    public class TaxCalculator
    {
        public double TaxFor(double grossSalary)
        {
            var upperTaxBracketStart = 40000;
            var upperTaxBracketRate = 0.4;
            var upperTaxBracketTax = TaxInBand(grossSalary, upperTaxBracketStart, upperTaxBracketRate);
            var remainingGrossForMiddleAndLowerBrackets = GrossToTaxInBandBelowCurrent(grossSalary, upperTaxBracketStart);

            var middleTaxBracketStart = 20000;
            var middleTaxBracketRate = 0.2;
            var middleTaxBracketTax = TaxInBand(remainingGrossForMiddleAndLowerBrackets, middleTaxBracketStart, middleTaxBracketRate);
            var remainingGrossForLowerBracket = GrossToTaxInBandBelowCurrent(remainingGrossForMiddleAndLowerBrackets, middleTaxBracketStart);

            var lowerTaxBracketStart = 5000;
            var lowerTaxBracketRate = 0.1;
            var lowerTaxBracketTax = TaxInBand(remainingGrossForLowerBracket, lowerTaxBracketStart, lowerTaxBracketRate);

            return lowerTaxBracketTax + middleTaxBracketTax + upperTaxBracketTax;
        }

        private double TaxInBand(double grossSalaryExcludingPartAlreadyTaxedAtHigherRate, double bracketMinimumGross,
            double taxRate) {
            return GrossToTaxInBand(grossSalaryExcludingPartAlreadyTaxedAtHigherRate, bracketMinimumGross) * taxRate;
        }

        private double GrossToTaxInBandBelowCurrent(double grossSalary, double bracketMinimumGross) {
            return Math.Min(grossSalary, bracketMinimumGross);
        }

        private double GrossToTaxInBand(double grossSalaryExcludingPartAlreadyTaxedAtHigherRate, double bracketMinimumGross) {
            return Math.Max(0, grossSalaryExcludingPartAlreadyTaxedAtHigherRate - bracketMinimumGross);
        }
    }
}