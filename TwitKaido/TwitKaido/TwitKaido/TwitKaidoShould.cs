using System;
using System.Collections.Generic;
using Xunit;

namespace TwitKaido
{
    public class TwitKaidoShould
    {
        [Fact]
        public void ReturnHoliAndHowAreYouOfUserAdriaAfterIntroduceTwoPosts()
        {
            var firstPost = "Adria -> Holi";
            var secondPost = "Adria -> How are you";    

            List<string> posts = new List<string>{ firstPost, secondPost };

            TwitKaido twitKaido = new TwitKaido(posts);

            var result = twitKaido.ReturnPosts();

            Assert.Equal(new List<string>{ "Holi", "How are you" }, result);   
        }
    }
}
