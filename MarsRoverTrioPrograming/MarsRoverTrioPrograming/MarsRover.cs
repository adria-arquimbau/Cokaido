using System;
using System.Collections.Generic;

namespace MarsRoverTrioPrograming
{
    public enum Commands
    {
        Move,
        Right,
        Left
    }

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
                ExecuteCommand(CommandFactory.GenerateCommandFromText(command));
            }

            return _position.ToString();
        }

        private void ExecuteCommand(Commands command)
        {
            if (command == Commands.Move)
            {
                _position.Move();
            }

            if (command == Commands.Right)
            {
                _position.TurnRight();
            }

            if (command == Commands.Left)
            {
                _position.TurnLeft();
            }
        }
    }
}