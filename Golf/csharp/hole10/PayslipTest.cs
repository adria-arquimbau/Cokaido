using Xunit;

namespace RefactoringGolf.hole10
{
    public class AnotherDummyTaxCalculator : hole09.ITaxCalculator
    {
        public double TaxFor(double grossSalary)
        {
            return 500;
        }
    }
    
    public class PayslipTest {
        [Fact]
        public void NetIsGrossMinusTax() {
            var payslip = new hole09.Payslip(5000, new AnotherDummyTaxCalculator());
            Assert.Equal(4500, payslip.GetNet(), 2);
        }
    }
}
