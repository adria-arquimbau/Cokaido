using System;

namespace RefactoringGolf.hole01
{
    public class Payslip {
        private readonly double grossSalary;

        public Payslip(double grossSalary) {
            this.grossSalary = grossSalary;
        }

        public double GetNet() {
            var lowerTaxBracketGross = Math.Max(Math.Min(grossSalary, 20000.0) - 5000, 0.0);
            var middleTaxBracketGross = Math.Max(Math.Min(grossSalary, 40000) - 20000, 0.0);
            var upperTaxBracketGross = Math.Max(grossSalary - 40000, 0.0);
            return grossSalary - (lowerTaxBracketGross * 0.1 + middleTaxBracketGross * 0.2 + upperTaxBracketGross * 0.4);
        }
    }
}
