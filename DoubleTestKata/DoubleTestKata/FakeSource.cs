namespace DoubleTestKata
{
    public class FakeSource : ISource
    {
        private string _stringChain;

        public FakeSource(string stringChain)
        {
            _stringChain = stringChain;
        }

        public char GetChar()
        {
            var returnChar = _stringChain[0];

            if (returnChar == '\n')
            {
                return returnChar;
            }

            _stringChain = _stringChain.Substring(1);
            return returnChar;
        }
    }
}