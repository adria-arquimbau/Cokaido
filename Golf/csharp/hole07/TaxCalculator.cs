using System;

namespace Payroll.Hole07
{
public class TaxCalculator {

    public double TaxFor(double grossSalary) {
        var lowerTaxBand = new TaxBand(5000.0, 0.1, null);
        var middleTaxBand = new TaxBand(20000.0, 0.2, lowerTaxBand);
        var upperTaxBand = new TaxBand(40000.0, 0.4, middleTaxBand);

        return upperTaxBand.TaxFor(grossSalary);
    }

    private class TaxBand {
		private double minimumGross;
		private double taxRate;
        private TaxBand lowerTaxBand;

        public TaxBand(double minimumGross, double taxRate, TaxBand lowerTaxBand) {
			this.minimumGross = minimumGross;
			this.taxRate = taxRate;
            this.lowerTaxBand = lowerTaxBand;
        }

		private double GrossInBand(double glossSalary) {
			return Math.Max(0, glossSalary - minimumGross);
		}

		public double GrossToTaxAtLowerBand(double grossSalary) {
			return Math.Min(grossSalary, minimumGross);
		}

		public double TaxForBand(double glossSalary) {
			return GrossInBand(glossSalary) * taxRate;
		}

        private double TaxForLowerBrands(double grossSalary) {
            return lowerTaxBand?.TaxFor(GrossToTaxAtLowerBand(grossSalary)) ?? 0;
        }

        public double TaxFor(double grossSalary) {
            return TaxForBand(grossSalary) + TaxForLowerBrands(grossSalary);
        }
    }
}
}