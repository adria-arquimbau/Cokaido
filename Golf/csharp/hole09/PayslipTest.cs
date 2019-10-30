using Xunit;

namespace RefactoringGolf.hole09
{
    public class AnotherDummyTaxCalculator : ITaxCalculator
    {
        public double TaxFor(double grossSalary)
        {
            return 500;
        }
    }
    
    public class PayslipTest {
        [Fact]
        public void NetIsGrossMinusTax() {
            var payslip = new Payslip(5000, new AnotherDummyTaxCalculator());
            Assert.Equal(4500, payslip.GetNet(), 2);
        }
    }
}
