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

        public Posts Output(string command)
        {
            var allPosts = new List<string>();

            foreach (var post in _posts)
            {
                if(command.Contains("wall"))
                    ReturnPostOfAnSpecificUserWithoutNameAnArrow(command, post, allPosts);
            }

            return new Posts(allPosts);
        }

        private static void ReturnPostOfAnSpecificUserWithoutNameAnArrow(string command, string post, List<string> allPosts)
        {
            string space = " ";
            string arrow = " -> ";

            var splitPost = post.Split(arrow);
            var commandSplit = command.Split(space);

            if (post.Contains(arrow) && splitPost[0] == commandSplit[0])
            {   
                allPosts.Add(splitPost[1]);
            }

            if (!post.Contains(arrow))
            {
                allPosts.Add(post);
            }
        }
    }
} 