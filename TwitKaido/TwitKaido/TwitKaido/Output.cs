using System.Collections.Generic;

namespace TwitKaidoKata
{
    public class Output
    {
        private readonly List<string> _output;

        public Output(List<string> output)
        {
            _output = output;
        }

        protected bool Equals(Output other)
        {
            if (this._output.Count != other._output.Count)
            {
                return false;
            }

            foreach (var output in _output)
            {
                if (!other._output.Contains(output)) return false;
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Output)obj);
        }

        public override int GetHashCode()
        {
            return (_output != null ? _output.GetHashCode() : 0);
        }
    }
}