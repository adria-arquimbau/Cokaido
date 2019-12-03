using System;
using NSubstitute;
using Xunit;

namespace MorseDecoderKata
{
    public class MorseDecoderShould 
    {
        [Fact]
        public void DecodeGivenValueIntoDestinationWithMocks()
        {
            var inputMorseCode = ".-";
            var fakeSend = Substitute.For<ISend>();

            var fakeGet = Substitute.For<IGet>();
        }
    }

    public interface IGet
    {
        void SetChar(char character);
    }

    public interface ISend
    {
        char GetChar();
    }
}
