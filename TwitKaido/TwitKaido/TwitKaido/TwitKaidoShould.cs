using System;
using System.Collections.Generic;
using Xunit;

namespace TwitKaido
{
    public class TwitKaidoShould
    {
        [Fact]
        public void ThrowExceptionIfMessageLengthIsZero()
        {
            var message = "";
            TwitKaido twitkaido = new TwitKaido(message);
            Assert.Throws<Exception>(() => twitkaido.ReturnMessage());
        }

        [Fact]
        public void ReturnHelloWhenAUserPostSameMessage()
        {
            var message = "Hello";
            TwitKaido twitKaido = new TwitKaido(message);

            var result = twitKaido.ReturnMessage();

            Assert.Equal("Hello", result);
        }
    }
}
