namespace RefactoringGolf.hole10
{
	public class NullTaxCalculator : ITaxCalculator {
		public double TaxFor(double grossSalary) {
			return 0;
		}
	}
}
