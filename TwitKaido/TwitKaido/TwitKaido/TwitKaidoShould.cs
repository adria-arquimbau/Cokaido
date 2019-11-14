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
            var post = "";
            TwitKaido twitKaido = new TwitKaido(post);
            Assert.Throws<Exception>(() => twitKaido.ReturnMessage());
        }

        [Fact]
        public void ReturnHelloWhenAUserPostSameMessage()
        {
            var post = "Hello";
            TwitKaido twitKaido = new TwitKaido(post);

            var result = twitKaido.ReturnMessage();

            Assert.Equal("Hello", result);
        }

        [Fact]
        public void ReturnMessageWithoutUserIfMessageContainsTheNameOfUserFollowedOfAnArrowAndTheMessage()
        {
            var post = "Adria -> Holi";
            TwitKaido twitKaido = new TwitKaido(post);
            var result = twitKaido.ReturnMessage();
            Assert.Equal("Holi", result);
        }
    }
}
