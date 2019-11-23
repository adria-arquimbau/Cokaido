using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class RoverBase : Rover
    {
        
        private readonly Dictionary<Compass, Action> _moveDictionary;
        private readonly Position _position;

        public RoverBase()
        {
            _moveDictionary = new Dictionary<Compass, Action>
            {
                {Compass.N, MoveNorth},
                {Compass.E, MoveEast},
                {Compass.S, MoveSouth},
                {Compass.W, MoveWest}
            };
            _position = new Position(0,0, Compass.N);
        }

        public override Position Execute(string commands)
        {
            foreach (var command in commands)
            {
                Action(command);
            }

            return _position;
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
                Move();
            }
        }

        private void Move()
        {
            _moveDictionary[_position.Compass]();
        }

        private void MoveNorth()
        {
            _position.PositionY++;
        }

        private void MoveSouth()
        {
            _position.PositionY--;
        }

        private void MoveWest()
        {
            _position.PositionX--;
            return;
        }

        private void MoveEast()
        {
            _position.PositionX++;
            return;
        }

        private void TurnLeft()
        {
            if (_position.Compass == Compass.N)
            {
                _position.Compass = Compass.W;
                return;
            }

            _position.Compass--;
        }

        public void TurnRight()
        {
            if (_position.Compass == Compass.W)
            {
                _position.Compass = Compass.N;
                return;
            }

            _position.Compass++;
        }
    }
}