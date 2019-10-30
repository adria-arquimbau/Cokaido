using Xunit;

namespace RefactoringGolf.hole05
{

public class PayslipTest {
    [Fact]
    public void TaxIsZeroIfGrossIsBelowTaxFreeLimit() {
        AssertNetGivenGross(5000, 5000);
    }

    [Fact]
    public void TaxOnAmountInLowerTaxBracketExcludesTaxFreeLimit() {
        AssertNetGivenGross(10000, 9500);
        AssertNetGivenGross(20000, 18500);
    }

    [Fact]
    public void TaxOnAmountInMiddleTaxBracketIsSumOfLowerTaxBracketAmountAndAdditionalMiddleTaxBracketAmount() {
        AssertNetGivenGross(25000, 22500);
        AssertNetGivenGross(40000, 34500);
    }

    [Fact]
    public void TaxOnAmountInUpperTaxBracketIsSumOfLowerTaxBracketAmountAndMiddleTaxBracketAmountAndAdditionalUpperTaxBracketAmount() {
        AssertNetGivenGross(50000, 40500);
        AssertNetGivenGross(60000, 46500);
    }

    private void AssertNetGivenGross(int gross, int expectedNet) {
        var payslip = new Payslip(gross, new TaxCalculator());
        Assert.Equal(expectedNet, payslip.GetNet(), 2);
    }
}
}