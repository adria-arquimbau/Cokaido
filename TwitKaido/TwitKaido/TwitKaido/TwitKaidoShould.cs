using System;
using System.Collections.Generic;
using Xunit;

namespace TwitKaido
{
    public class TwitKaidoShould
    {
        [Fact]
        public void ReturnTheSamePostAfterIntroduceAPost()
        {
            List<string> post = new List<string>{ "My first post" };
            TwitKaido twitKaido = new TwitKaido(post);
            string userToReturnPost = "Adria";

            var result = twitKaido.ReturnPosts(userToReturnPost);
            Assert.Equal(new List<string>{ "My first post" }, result);
        }

        [Fact]
        public void ReturnHoliAndHowAreYouOfUserAdriaAfterIntroduceTwoPosts()
        {
            var firstPost = "Adria -> Holi";
            var secondPost = "Adria -> How are you";    

            List<string> posts = new List<string>{ firstPost, secondPost };

            TwitKaido twitKaido = new TwitKaido(posts);
            string userToReturnPost = "Adria";

            var result = twitKaido.ReturnPosts(userToReturnPost);

            Assert.Equal(new List<string>{ "Holi", "How are you" }, result);   
        }

        [Fact]
        public void ReturnAllMessagesAfterIntroduceMessagesOnAList()
        {
            var firstPost = "Adria -> Holi";
            var secondPost = "Adria -> How are you";
            var thirdPost = "Adria -> Where are you from?";

            List<string> posts = new List<string> { firstPost, secondPost, thirdPost };

            TwitKaido twitKaido = new TwitKaido(posts);
            string userToReturnPost = "Adria";
            var result = twitKaido.ReturnPosts(userToReturnPost);

            Assert.Equal(new List<string> { "Holi", "How are you", "Where are you from?"}, result);
        }

        [Fact]
        public void ReturnsPostOfAdriaAfterIntroduceOnePostFromAnnaAndOneFromAdria()
        {
            string adriaPost = "Adria -> Hello! My name is Adria";
            string annaPost = "Anna -> Hey! My name is Anna";
            List<string> posts = new List<string>{ adriaPost, annaPost };
            TwitKaido twitKaido = new TwitKaido(posts);
            string userToReturnPost = "Adria";
            var result = twitKaido.ReturnPosts(userToReturnPost);
            Assert.Equal(new List<string>{ "Hello! My name is Adria" }, result);
        }
    }
}
