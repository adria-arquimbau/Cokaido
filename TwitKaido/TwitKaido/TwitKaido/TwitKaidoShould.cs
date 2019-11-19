using System;
using System.Collections.Generic;
using System.Dynamic;
using Xunit;

namespace TwitKaidoKata
{
    public class TwitKaidoShould    
    {
        //[Fact]
        //public void ReturnAdriaPostsIntroducingAdriaWallAfterIntroduceOnePostFromAdria()
        //{
        //    TwitKaido twitKaido = new TwitKaido();
        //    string adriaPost = "Adria -> Hello dude!";
        //    twitKaido.AddPost(adriaPost);
                
        //    string command = "Adria wall";
        //    var result = twitKaido.Output(command);
        //    List<string> expectedListPosts = new List<string> {"Hello dude!"};
        //    Input expectedInput = new Input(expectedListPosts);
        //    Assert.Equal(expectedInput, result);
        //}   

        //[Fact]
        //public void ReturnAnnaPostsIntroducingAnnaWallAfterOnePostFromAnnaAndTwoMorePostsFromAnotherUsers()
        //{
            
        //    string adriaPost = "Adria -> Hello dude!";
        //    string annaPost = "Anna -> Hello my name is Anna";
        //    string jaumePost = "Jaume -> Jaume al aparato!";

        //    twitKaido.AddPost(adriaPost);
        //    twitKaido.AddPost(annaPost);
        //    twitKaido.AddPost(jaumePost);

        //    List<string> postsList = new List<string>{ adriaPost, annaPost, jaumePost };
        //    new Input(postsList);

        //    string command = "Anna wall";
        //    var result = twitKaido.Output(command);

        //    List<string> expectedListPosts = new List<string>{ "Hello my name is Anna" };
        //    Input expectedInput = new Input(expectedListPosts);
            
        //    Assert.Equal(expectedInput, result);
        //}

        //[Fact]
        //public void ReturnJaumePostsIntroducingJaumeWallAfterTwoPostsFromJaumeAndSixMorePostsFromAnotherUsers()
        //{
        //    TwitKaido twitKaido = new TwitKaido();
        //    string adriaFirstPost = "Adria -> Hello dude!";
        //    string adriaSecondPost = "Adria -> Alguien quiere ser mi amigo?";
        //    string annaFirstPost = "Anna -> Hello my name is Anna";
        //    string annaSecondPost = "Anna -> Tengo 38 tacos o.O!";
        //    string jaumeFirstPost = "Jaume -> Jaume al aparato!";
        //    string jaumeSecondPost = "Jaume -> Alguien se apunta a salir a correr?";
        //    string josepFirstPost = "Josep -> Josep es mi nobre";
        //    string xaviFirstPost = "Xavi -> Soy nuevo en esto, me llamo Xavi";

        //    twitKaido.AddPost(adriaFirstPost);
        //    twitKaido.AddPost(adriaSecondPost);
        //    twitKaido.AddPost(annaFirstPost);
        //    twitKaido.AddPost(annaSecondPost);
        //    twitKaido.AddPost(jaumeFirstPost);
        //    twitKaido.AddPost(jaumeSecondPost);
        //    twitKaido.AddPost(josepFirstPost);
        //    twitKaido.AddPost(xaviFirstPost);

        //    string command = "Anna wall";
        //    var result = twitKaido.Output(command);

        //    List<string> expectedListPosts = new List<string> { "Hello my name is Anna", "Tengo 38 tacos o.O!" };
        //    Input expectedInput = new Input(expectedListPosts);

        //    Assert.Equal(expectedInput, result);
        //}

        [Fact]
        public void ReturnAdriaPostAfterIntroduceCommandAdriaWall()
        {
            List<string> expectedOutputList =  new List<string>{ "Hello!" };
            Output expectedOutput = new Output(expectedOutputList);

            string post = "Adria -> Hello!";
            var inputCommand = new Input(post);

            TwitKaido twitKaido = new TwitKaido(inputCommand);

            string command = "Adria wall";
            var result = twitKaido.Post(command);

            Assert.Equal(expectedOutput, result);   
        }

        [Fact]
        public void ReturnAnnaPostAfterIntroduceCommandAnnaWall()
        {
            List<string> expectedOutputList = new List<string> { "Hello my name is Anna" };
            Output expectedOutput = new Output(expectedOutputList);

            string annaFirstPost = "Anna -> Hello my name is Anna";

            var inputCommand = new Input(annaFirstPost);

            TwitKaido twitKaido = new TwitKaido(inputCommand);

            string command = "Anna wall";
            var result = twitKaido.Post(command);

            Assert.Equal(expectedOutput, result);
        }
    }
}
    