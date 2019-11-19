using System;
using System.Collections.Generic;

namespace TwitKaido
{
    public class TwitKaido
    {
        private readonly List<string> _posts;

        public TwitKaido()
        {
            _posts = new List<string>();
        }

        public void AddPost(string post)
        {
           _posts.Add(post);
        }

        public List<string> Output(string command)
        {
            var allPosts = new List<string>();

            foreach (var post in _posts)
            {
                if(command.Contains("wall"))
                    ReturnPostOfAnSpecificUserWithoutNameAnArrow(command, post, allPosts);
            }

            return allPosts;
        }

        private static void ReturnPostOfAnSpecificUserWithoutNameAnArrow(string command, string post, List<string> allPosts)
        {
            var splitPost = post.Split(" -> ");
            var commandSplit = command.Split(" ");

            if (post.Contains("->") && splitPost[0] == commandSplit[0])
            {   
                allPosts.Add(splitPost[1]);
            }

            if (!post.Contains("->"))
            {
                allPosts.Add(post);
            }
        }
    }
} 