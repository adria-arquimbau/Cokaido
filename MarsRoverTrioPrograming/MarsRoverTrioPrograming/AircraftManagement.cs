using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace MarsRoverTrioPrograming
{
    public class AircraftManagement
    {
        private int _fuel;
        private readonly Axis _axis;
        private readonly List<Compass> _wayBack = new List<Compass>();
        private int _fuelToReturnHome;
        private readonly Dictionary<Compass,Compass> _goBackCompass ;
        private readonly Dictionary<Compass, Action> _navigateToDictionary;
        private const int Empty = 0;
        
        public AircraftManagement(int fuel, Axis axis)
        {
            _fuel = fuel;
            _axis = axis;
            CalculateFuelToReturnHome(fuel);
            _goBackCompass = new Dictionary<Compass, Compass>
            {
                {Compass.N, Compass.S}, 
                {Compass.S, Compass.N},
                {Compass.W, Compass.E},
                {Compass.E, Compass.W}, 
                {Compass.NE, Compass.SW},
                {Compass.NW, Compass.SE},
                {Compass.SE, Compass.NW},
                {Compass.SW, Compass.NE},
            };
            _navigateToDictionary = new Dictionary<Compass, Action>
            {
                {Compass.N, _axis.MoveNorth},
                {Compass.NE, _axis.MoveNorthEast},
                {Compass.E, _axis.MoveEast},
                {Compass.SE, _axis.MoveSouthEast},
                {Compass.S, _axis.MoveSouth},
                {Compass.SW, _axis.MoveSouthWest},
                {Compass.W, _axis.MoveWest},
                {Compass.NW, _axis.MoveNorthWest}
            };
        }

        public void NavigateTo(Compass compass)
        {
            if (_fuel == Empty)
            {
                return;
            }

            if (_fuel > _fuelToReturnHome)
            {
                _navigateToDictionary[compass]();
                _wayBack.Add(_goBackCompass[compass]);
                _fuel--;
            }

            if (_fuel <= _fuelToReturnHome)
            {
                GoHome();
            }
        }

        private void GoHome()
        {
            foreach (var compass in _wayBack)
            {
                _navigateToDictionary[compass]();
                _fuel--;
            }
        }


        private void CalculateFuelToReturnHome(int fuel)
        {
            _fuelToReturnHome = _fuel / 2 + fuel % 2;
        }
    }
}