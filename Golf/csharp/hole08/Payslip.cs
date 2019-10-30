namespace RefactoringGolf.hole08
{
    public class Payslip
    {
        private readonly double grossSalary;
        private readonly TaxCalculator taxCalculator;

        public Payslip(double grossSalary, TaxCalculator taxCalculator)
        {
            this.grossSalary = grossSalary;
            this.taxCalculator = taxCalculator;
        }

        public double GetNet()
        {
            return grossSalary - taxCalculator.TaxFor(grossSalary);
        }
    }
}