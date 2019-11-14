namespace InappropriateIntimacy
{
    public class License
    {
        private Motorist motorist;

        public Motorist Motorist
        {
            set
            {
                motorist = value;
            }
        }

        public int Points { get; private set; }

        public Motorist Motorist1
        {
            set { motorist = value; }
            get { return motorist; }
        }

        public void addPoints(int points)
        {   
            this.Points += points;
        }

        public RiskFactor GetRiskFactor()
        {
            if (this.Points > 3)
            {
                return RiskFactor.HIGH_RISK;
            }

            if (this.Points > 0)
            {
                return RiskFactor.MODERATE_RISK;
            }

            return RiskFactor.LOW_RISK;
        }
    }
}