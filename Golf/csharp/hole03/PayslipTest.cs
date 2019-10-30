using Xunit;

namespace RefactoringGolf.hole03
{
    public class PayslipTest
    {
        [Fact]
        public void TaxIsZeroIfGrossIsBelowTaxFreeLimit()
        {
            var payslip = new Payslip(5000, new TaxCalculator());
            Assert.Equal(5000, payslip.GetNet(), 2);
        }

        [Fact]
        public void TaxOnAmountInLowerTaxBracketExcludesTaxFreeLimit()
        {
            var payslip = new Payslip(10000, new TaxCalculator());
            Assert.Equal(9500, payslip.GetNet(), 2);

            var payslip2 = new Payslip(20000, new TaxCalculator());
            Assert.Equal(18500, payslip2.GetNet(), 2);
        }

        [Fact]
        public void TaxOnAmountInMiddleTaxBracketIsSumOfLowerTaxBracketAmountAndAdditionalMiddleTaxBracketAmount()
        {
            var payslip = new Payslip(25000, new TaxCalculator());
            Assert.Equal(22500, payslip.GetNet(), 2);

            var payslip2 = new Payslip(40000, new TaxCalculator());
            Assert.Equal(34500, payslip2.GetNet(), 2);
        }

        [Fact]
        public void
            TaxOnAmountInUpperTaxBracketIsSumOfLowerTaxBracketAmountAndMiddleTaxBracketAmountAndAdditionalUpperTaxBracketAmount()
        {
            var payslip = new Payslip(50000, new TaxCalculator());
            Assert.Equal(40500, payslip.GetNet(), 2);

            var payslip2 = new Payslip(60000, new TaxCalculator());
            Assert.Equal(46500, payslip2.GetNet(), 2);
        }
    }
}