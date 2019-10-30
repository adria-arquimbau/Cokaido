using Payroll.Hole07;
using TaxCalculator = RefactoringGolf.hole08.TaxCalculator;

namespace RefactoringGolf.hole07
{
    public class Payslip
    {
        private readonly double grossSalary;
        private readonly hole08.TaxCalculator taxCalculator;

        public Payslip(double grossSalary, hole08.TaxCalculator taxCalculator)
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