using System.Runtime.InteropServices.ComTypes;

namespace DoubleTestKata
{
    public class SpyDestination : IDestination
    {
        private string _savedChars;

        public void SetChar(char character)
        {
            _savedChars += character;
        }
            
        public string GetCopiedChars()
        {
            return _savedChars;
        }
    }
}