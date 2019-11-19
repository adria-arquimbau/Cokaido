using System;
using System.Collections.Generic;

namespace TwitKaido
{
    public class TwitKaido
    {
        private readonly List<string> _posts;

        public TwitKaido(List<string> posts)
        {
            _posts = posts;
        }

        public List<string> ReturnPosts()
        {
            var allPosts = new List<string>();

            foreach (var post in _posts)
            {
                if (post.Contains("->"))
                {
                    var splitPost = post.Split(" -> ");

                    allPosts.Add(splitPost[1]);
                }
                if(!post.Contains("->"))
                    allPosts.Add(post);
                
            }

            return allPosts;
        }
    }
}