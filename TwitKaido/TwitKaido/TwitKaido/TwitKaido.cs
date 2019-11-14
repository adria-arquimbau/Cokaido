using System;
using System.Collections.Generic;

namespace TwitKaido
{
    public class TwitKaido
    {
        private readonly List<string> _posts;
        private readonly string _message;

        public TwitKaido(List<string> posts)
        {
            _posts = posts;
        }

        public List<string> ReturnPosts()
        {
            var allPosts = new List<string>();

            foreach (var post in _posts)
            {
                var splitPost = post.Split(" -> ");

                allPosts.Add(splitPost[1]);
            }

            return allPosts;
        }
    }
}