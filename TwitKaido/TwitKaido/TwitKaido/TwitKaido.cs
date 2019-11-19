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
                ReturnPostWithoutNameAndArrow(post, allPosts);
            }

            return allPosts;
        }

        public List<string> ReturnPosts(string userToReturnPosts)
        {
            var allPosts = new List<string>();

            foreach (var post in _posts)
            {
                var splitPost = post.Split(" -> ");

                if (post.Contains("->") && splitPost[0] == userToReturnPosts)
                {
                    allPosts.Add(splitPost[1]);
                }

                if (!post.Contains("->") && splitPost[0] == userToReturnPosts)
                {
                    allPosts.Add(post);
                }
                  
            }

            return allPosts;
        }

        private static void ReturnPostWithoutNameAndArrow(string post, List<string> allPosts)
        {
            if (post.Contains("->"))
            {
                var splitPost = post.Split(" -> ");

                allPosts.Add(splitPost[1]);
            }

            if (!post.Contains("->"))
                allPosts.Add(post);
        }
    }
} 