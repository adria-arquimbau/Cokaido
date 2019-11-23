using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class Rover
    {
        private Compass _compass;
        private readonly Position _position;
        private readonly IMovement _movement;

        public Rover(IMovement movement)
        {
            _position = new Position(0,0);
            _movement = movement;
        }

        public string Execute(string commands)
        {
            foreach (var command in commands)
            {
                Action(command);
            }

            return $"{_position.PositionX}:{_position.PositionY}:{_compass}";
        }

        private void Action(char command)
        {
            if (command == 'L')
            {
                TurnLeft();
            }

            if (command == 'R')
            {
                TurnRight();
            }

            if (command == 'M')
            {
                _movement.Move(_position, _compass);
            }
        }

        private void TurnLeft()
        {
            if (_compass == Compass.N)
            {
                _compass = Compass.W;
                return;
            }

            _compass--;
        }

        public void TurnRight()
        {
            if (_compass == Compass.W)
            {
                _compass = Compass.N;
                return;
            }

            _compass++;
        }
    }
}