using System;
using System.Collections.Generic;

namespace TwitKaidoKata
{
    public class Input
    {
        private readonly string _post;
        private List<string> _allPosts = new List<string>();

        public Input(string post)
        {
            _post = post;
        }

        public Output HandlePost(string command)
        {
            var output = HandleOutput(_post, command);
            return output;
        }

        public Output HandleOutput(string input, string command)
        {
            string space = " ";
            string arrow = " -> ";

            List<string> newOutput = new List<string>();

            if (input.Contains("->"))
            {
                _allPosts.Add(input);
            }

            if (command.Contains("wall"))
            {
                var splitInput = input.Split(space);

                foreach (var post in _allPosts)
                {
                    if (post.Contains(splitInput[0]))
                    {
                        var splitPost = post.Split(arrow);

                        newOutput.Add(splitPost[1]);
                    }
                }
            }

            return new Output(newOutput);
        }
    }
}