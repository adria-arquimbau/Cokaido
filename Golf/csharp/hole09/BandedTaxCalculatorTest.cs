using Xunit;

namespace RefactoringGolf.hole09
{
	public class DummyTaxCalculator : ITaxCalculator
	{
		public double TaxFor(double grossSalary)
		{
			return 1;
		}
	}

	public class BandedTaxCalculatorTest
	{
		private const double RateForBand = 0.1;
		private const int MinimumGrossForBand = 1000;
		private const int TaxFromLowerBand = 1;
		private BandedTaxCalculator calculator = 
			new BandedTaxCalculator(MinimumGrossForBand, RateForBand,new DummyTaxCalculator());

		[Fact]
		public void LowerBandTaxIsZeroIfLowerBandCalculatorIsNull() {
			BandedTaxCalculator otherCalculator = new BandedTaxCalculator(MinimumGrossForBand, RateForBand, null);
			Assert.Equal(RateForBand * (2000 - MinimumGrossForBand), otherCalculator.TaxFor(2000), 0);
		}

		[Fact]
		public void AllTaxIsFromLowerBandsIfGrossSalaryIsLessThanMinimumForBand() {
			Assert.Equal(TaxFromLowerBand, calculator.TaxFor(MinimumGrossForBand), 0);
		}
	
		[Fact]
		public void TaxIsSumOfTaxFromLowerBandsAndTaxFromThisBand() {
			Assert.Equal(TaxFromLowerBand + RateForBand * (2000 - MinimumGrossForBand), calculator.TaxFor(2000), 0);
		}
	}
}