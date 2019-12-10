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
        private Dictionary<Compass, Action> _navigateToDictionary;
        const int Empty = 0;
        
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
            if (_fuel > _fuelToReturnHome)
            {
                _wayBack.Add(_goBackCompass[compass]);

                _navigateToDictionary[compass]();
                _fuel--;
            }


            if (_fuel == Empty)
            {
                return;
            }
        }


        private void CalculateFuelToReturnHome(int fuel)
        {
            _fuelToReturnHome = _fuel / 2 + fuel % 2;
        }       
        
    }
}