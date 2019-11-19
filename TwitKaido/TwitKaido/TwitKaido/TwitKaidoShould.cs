using System;
using System.Collections.Generic;
using Xunit;

namespace TwitKaido
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
            Assert.Equal(new List<string>{ "Hello dude!" }, result);
        }
    }
}
