using System;

namespace RefactoringGolf.hole09
{
	public class BandedTaxCalculator : ITaxCalculator {
		private double minimumGross;
		private double taxRate;
		private ITaxCalculator lowerBandCalculator;

		public BandedTaxCalculator(double minimumGross, double taxRate, ITaxCalculator lowerBandCalculator) {
			this.minimumGross = minimumGross;
			this.taxRate = taxRate;
			this.lowerBandCalculator = lowerBandCalculator;
		}

		public double TaxFor(double grossSalary) {
			return TaxForBand(grossSalary) + TaxForLowerBands(grossSalary);
		}

		private double TaxForLowerBands(double grossSalary) {
			return lowerBandCalculator?.TaxFor(GrossToTaxAtLowerBand(grossSalary)) ?? 0;
		}

		private double GrossToTaxAtLowerBand(double grossSalary) {
			return Math.Min(grossSalary, minimumGross);
		}

		private double TaxForBand(double grossSalary) {
			return GrossInBand(grossSalary) * taxRate;
		}

		private double GrossInBand(double grossSalary) {
			return Math.Max(0, grossSalary - minimumGross);
		}
	}
}