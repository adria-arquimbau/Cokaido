using System;

namespace TwitKaido
{
    public class TwitKaido
    {
        private readonly string _post;

        public TwitKaido(string post)
        {
            _post = post;
        }

        public string ReturnMessage()
        {
            if(_post.Length == 0)
            {
                throw new Exception();
            }

            if (_post.Contains("->"))
            {
                var splitedPost = _post.Split(" ");

                return splitedPost[2];
            }

            return _post;
        }
    }
}