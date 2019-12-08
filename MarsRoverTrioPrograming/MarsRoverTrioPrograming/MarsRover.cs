using System;
using System.Collections.Generic;
using MarsRoverTrioPrograming.Tests;

namespace MarsRoverTrioPrograming
{
    public class MarsRover
    {
        private readonly IPosition _position;

        public MarsRover(IPosition position = null, Axis obstacle = null)
        {
            _position = position ?? new Position(Compass.N,0,0, obstacle);
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