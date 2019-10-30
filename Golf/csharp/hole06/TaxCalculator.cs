using System;

namespace RefactoringGolf.hole06
{
    public class TaxCalculator {

        public double TaxFor(double grossSalary) {
            var upperTaxBand = new TaxBand(40000.0, 0.4);
            var upperTaxBracketTax = upperTaxBand.TaxInBand(grossSalary);
			var remainingGrossForMiddleAndLowerBrackets = upperTaxBand.GrossToTaxInBandsBelowCurrent(grossSalary);

            var middleTaxBand = new TaxBand(20000.0, 0.2);
            var middleTaxBracketTax = middleTaxBand.TaxInBand(remainingGrossForMiddleAndLowerBrackets);
			var remainingGrossForLowerBracket = middleTaxBand.GrossToTaxInBandsBelowCurrent(remainingGrossForMiddleAndLowerBrackets);

            var lowerTaxBand = new TaxBand(5000.0, 0.1);
            var lowerTaxBracketTax = lowerTaxBand.TaxInBand(remainingGrossForLowerBracket);
        
			return lowerTaxBracketTax + middleTaxBracketTax + upperTaxBracketTax;
		}

        public class TaxBand {
            private double minimumGross;
            private double taxRate;

            public TaxBand(double minimumGross, double taxRate) {
                this.minimumGross = minimumGross;
                this.taxRate = taxRate;
            }

            private double GrossToTaxInBand(double grossSalaryExcludingPartAlreadyTaxedAtHigherRate) {
                return Math.Max(0, grossSalaryExcludingPartAlreadyTaxedAtHigherRate - minimumGross);
            }

            public double GrossToTaxInBandsBelowCurrent(double grossSalary) {
                return Math.Min(grossSalary, minimumGross);
            }

            public double TaxInBand(double grossSalaryExcludingPartAlreadyTaxedAtHigherRate) {
                return GrossToTaxInBand(grossSalaryExcludingPartAlreadyTaxedAtHigherRate) * taxRate;
            }
        }
    }
}
