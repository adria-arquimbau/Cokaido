using System;
using System.Collections.Generic;
using Xunit;

namespace TwitKaidoKata
{
    public class TwitKaidoShould    
    {
        [Fact]
        public void ReturnAdriaPostsIntroducingAdriaWallAfterIntroduceOnePostFromAdria()
        {
            TwitKaido twitKaido = new TwitKaido();
            string adriaPost = "Adria -> Hello dude!";
            twitKaido.AddPost(adriaPost);
                
            string command = "Adria wall";
            var result = twitKaido.Output(command);
            List<string> expectedListPosts = new List<string> {"Hello dude!"};
            Post expectedPost = new Post(expectedListPosts);
            Assert.Equal(expectedPost, result);
        }   

        [Fact]
        public void ReturnAnnaPostsIntroducingAnnaWallAfterOnePostFromAnnaAndTwoMorePostsFromAnotherUsers()
        {
            TwitKaido twitKaido = new TwitKaido();
            string adriaPost = "Adria -> Hello dude!";
            string annaPost = "Anna -> Hello my name is Anna";
            string jaumePost = "Jaume -> Jaume al aparato!";

            twitKaido.AddPost(adriaPost);
            twitKaido.AddPost(annaPost);
            twitKaido.AddPost(jaumePost);

            string command = "Anna wall";
            var result = twitKaido.Output(command);

            List<string> expectedListPosts = new List<string>{ "Hello my name is Anna" };
            Post expectedPost = new Post(expectedListPosts);
            
            Assert.Equal(expectedPost, result);
        }

        [Fact]
        public void ReturnJaumePostsIntroducingJaumeWallAfterTwoPostsFromJaumeAndSixMorePostsFromAnotherUsers()
        {
            TwitKaido twitKaido = new TwitKaido();
            string adriaFirstPost = "Adria -> Hello dude!";
            string adriaSecondPost = "Adria -> Alguien quiere ser mi amigo?";
            string annaFirstPost = "Anna -> Hello my name is Anna";
            string annaSecondPost = "Anna -> Tengo 38 tacos o.O!";
            string jaumeFirstPost = "Jaume -> Jaume al aparato!";
            string jaumeSecondPost = "Jaume -> Alguien se apunta a salir a correr?";
            string josepFirstPost = "Josep -> Josep es mi nobre";
            string xaviFirstPost = "Xavi -> Soy nuevo en esto, me llamo Xavi";

            twitKaido.AddPost(adriaFirstPost);
            twitKaido.AddPost(adriaSecondPost);
            twitKaido.AddPost(annaFirstPost);
            twitKaido.AddPost(annaSecondPost);
            twitKaido.AddPost(jaumeFirstPost);
            twitKaido.AddPost(jaumeSecondPost);
            twitKaido.AddPost(josepFirstPost);
            twitKaido.AddPost(xaviFirstPost);

            string command = "Anna wall";
            var result = twitKaido.Output(command);

            List<string> expectedListPosts = new List<string> { "Hello my name is Anna", "Tengo 38 tacos o.O!" };
            Post expectedPost = new Post(expectedListPosts);

            Assert.Equal(expectedPost, result);
        }

        [Fact]
        public void ReturnAdriaPostsAfterIntroduceOnePostFromAdriaThenOnePostFromJaumeAfterIntrouceCommandAdriaWallThenIntroduceAnotherPostFromAdria()
        {
            TwitKaido twitKaido = new TwitKaido();
            string adriaFirstPost = "Adria -> Hello dude!";
            string adriaSecondPost = "Adria -> Alguien quiere ser mi amigo?";
            string jaumeFirstPost = "Jaume -> Jaume al aparato!";

            twitKaido.AddPost(adriaFirstPost);
            twitKaido.AddPost(adriaSecondPost);
            twitKaido.AddPost(jaumeFirstPost);

            string command = "Adria wall";
            var result = twitKaido.Output(command);

            twitKaido.AddPost(adriaSecondPost);

            List<string> expectedListPosts = new List<string> { "Hello dude!", "Alguien quiere ser mi amigo?" };
            Post expectedPost = new Post(expectedListPosts);

            Assert.Equal(expectedPost, result);
        }

    }
}
