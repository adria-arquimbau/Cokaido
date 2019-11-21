using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class Rover
    {
        private Compass _compass;
        private int _positionY = 0;
        private int _positionX = 0;
        private readonly Dictionary<Compass, Action> _moveDictionary;

        public Rover()
        {
            _moveDictionary = new Dictionary<Compass, Action>
            {
                {Compass.N, MoveNorth},
                {Compass.E, MoveEast},
                {Compass.S, MoveSouth},
                {Compass.W, MoveWest}
            };
        }

        public string Execute(string commands)
        {
            foreach (var command in commands)
            {
                Action(command);
            }

            return $"{_positionX}:{_positionY}:{_compass}";
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
            _moveDictionary[_compass]();
        }

        private void MoveNorth()
        {
            _positionY++;
        }

        private void MoveSouth()
        {
            _positionY--;
        }

        private void MoveWest()
        {
            _positionX--;
            return;
        }

        private void MoveEast()
        {
            _positionX++;
            return;
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