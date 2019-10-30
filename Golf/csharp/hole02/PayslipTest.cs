using Xunit;

namespace RefactoringGolf.hole02
{
    public class PayslipTest
    {
        [Fact]
        public void TaxIsZeroIfGrossIsBelowTaxFreeLimit()
        {
            var payslip = new hole01.Payslip(5000);
            Assert.Equal(5000, payslip.GetNet(), 2);
        }

        [Fact]
        public void TaxOnAmountInLowerTaxBracketExcludesTaxFreeLimit()
        {
            var payslip = new hole01.Payslip(10000);
            Assert.Equal(9500, payslip.GetNet(), 2);

            var payslip2 = new hole01.Payslip(20000);
            Assert.Equal(18500, payslip2.GetNet(), 2);
        }

        [Fact]
        public void TaxOnAmountInMiddleTaxBracketIsSumOfLowerTaxBracketAmountAndAdditionalMiddleTaxBracketAmount()
        {
            var payslip = new hole01.Payslip(25000);
            Assert.Equal(22500, payslip.GetNet(), 2);

            var payslip2 = new hole01.Payslip(40000);
            Assert.Equal(34500, payslip2.GetNet(), 2);
        }

        [Fact]
        public void
            TaxOnAmountInUpperTaxBracketIsSumOfLowerTaxBracketAmountAndMiddleTaxBracketAmountAndAdditionalUpperTaxBracketAmount()
        {
            var payslip = new hole01.Payslip(50000);
            Assert.Equal(40500, payslip.GetNet(), 2);

            var payslip2 = new hole01.Payslip(60000);
            Assert.Equal(46500, payslip2.GetNet(), 2);
        }
    }
}