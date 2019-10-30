using Xunit;

namespace RefactoringGolf.hole09
{
    public class PayslipTaxTest {
        [Fact]
        public void TaxIsZeroIfGrossIsBelowTaxFreeLimit() {
            AssertNetForGross(5000, 5000);
        }

        [Fact]
        public void TaxOnAmountInLowerTaxBracketExcludesTaxFreeLimit() {
            AssertNetForGross(10000, 9500);
            AssertNetForGross(20000, 18500);
        }

        [Fact]
        public void TaxOnAmountInMiddleTaxBracketIsSumOfLowerTaxBracketAmountAndAdditionalMiddleTaxBracketAmount() {
            AssertNetForGross(25000, 22500);
            AssertNetForGross(40000, 34500);
        }

        [Fact]
        public void TaxOnAmountInUpperTaxBracketIsSumOfLowerTaxBracketAmountAndMiddleTaxBracketAmountAndAdditionalUpperTaxBracketAmount() {
            AssertNetForGross(50000, 40500);
            AssertNetForGross(60000, 46500);
        }

        private void AssertNetForGross(int gross, int expectedNet)
        {
            var payslip = new Payslip(gross,
                new BandedTaxCalculator(40000, 0.4,
                    new BandedTaxCalculator(20000, 0.2,
                        new BandedTaxCalculator(5000, 0.1, null))));
            Assert.Equal(expectedNet, payslip.GetNet(), 2);
        }
    }
}
