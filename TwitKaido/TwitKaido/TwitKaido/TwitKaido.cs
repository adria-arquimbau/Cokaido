using System;

namespace TwitKaido
{
    public class TwitKaido
    {
        private readonly string _message;

        public TwitKaido(string message)
        {
            _message = message;
        }

        public string ReturnMessage()
        {
            if(_message.Length == 0)
            {
                throw new Exception();
            }

            return _message;
        }
    }
}