namespace RefactoringGolf.hole10
{
    public class Payslip
    {
        private readonly double grossSalary;
        private readonly ITaxCalculator taxCalculator;

        public Payslip(double grossSalary, ITaxCalculator taxCalculator)
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