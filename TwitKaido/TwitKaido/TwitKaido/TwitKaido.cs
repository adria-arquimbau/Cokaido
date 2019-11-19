using System;
using System.Collections.Generic;

namespace TwitKaidoKata
{
    public class TwitKaido
    {
        private Input _inputs;

        public TwitKaido(Input input)
        {
            _inputs = input;
        }

        public Output Post(string command)
        {   
            var output = _inputs.HandlePost(command);
            return output;  
        }
    }
} 