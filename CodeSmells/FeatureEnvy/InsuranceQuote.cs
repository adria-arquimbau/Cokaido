namespace FeatureEnvy
{
    public class InsuranceQuote
    {
        public readonly Motorist motorist;

        public InsuranceQuote(Motorist motorist)
        {
            this.motorist = motorist;
        }

        public double CalculateInsurancePremium(double insuranceValue)
        {
            var riskFactor = motorist.CalculateMotoristRisk();

            switch (riskFactor)
            {
                case RiskFactor.LOW_RISK:
                    return insuranceValue * 0.02;
                case RiskFactor.MODERATE_RISK:
                    return insuranceValue * 0.04;
                default:
                    return insuranceValue * 0.06;
            }
        }
    }
}