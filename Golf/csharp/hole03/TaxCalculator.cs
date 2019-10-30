using System;

namespace RefactoringGolf.hole03
{
    public class TaxCalculator
    {
        public double TaxFor(double grossSalary)
        {
            var lowerTaxBracketGross = Math.Max(Math.Min(grossSalary, 20000.0) - 5000, 0.0);
            var middleTaxBracketGross = Math.Max(Math.Min(grossSalary, 40000) - 20000, 0.0);
            var upperTaxBracketGross = Math.Max(grossSalary - 40000, 0.0);
            return lowerTaxBracketGross * 0.1 + middleTaxBracketGross * 0.2 + upperTaxBracketGross * 0.4;
        }
    }
}