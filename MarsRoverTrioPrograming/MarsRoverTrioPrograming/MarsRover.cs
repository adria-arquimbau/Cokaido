using System;
using System.Collections.Generic;

namespace MarsRoverTrioPrograming
{

    public class MarsRover
    {
        private readonly Position _position;

        public MarsRover(Position position = null)
        {
            _position = position ?? new Position(Compass.N,0,0);
        }

        public string Execute(string textCommands)
        {
            foreach (var command in textCommands)
            {
                ExecuteCommand(CommandFactory.GenerateCommandFromText(command, _position));
            }

            return _position.ToString();
        }

        private void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }
    }
}