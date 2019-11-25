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
                if (CommandFactory.GenerateCommandFromText(command) == Commands.Move)
                {
                    _position.Move();
                }

                if (CommandFactory.GenerateCommandFromText(command) == Commands.Right)
                {
                    _position.TurnRight();
                }

                if (CommandFactory.GenerateCommandFromText(command) == Commands.Left)
                {
                    _position.TurnLeft();
                }
            }

            return _position.ToString();
        }
    }
}