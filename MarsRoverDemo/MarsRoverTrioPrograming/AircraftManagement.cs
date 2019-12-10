using System;
using System.Collections.Generic;

namespace MarsRoverDemo
{
    public class AircraftManagement
    {
        private int _fuel;
        private const int empty = 0;
        private readonly Axis _axis;
        private List<Compass> _wayBack = new List<Compass>();
        private readonly Dictionary<Compass, Action<Axis>> _navigateTo = new Dictionary<Compass, Action<Axis>>
        {
            {Compass.N, (axisToChange)=> { axisToChange.MoveNorth(); }},
            {Compass.NE, (axisToChange)=> { axisToChange.MoveNorthEast(); }},
            {Compass.E, (axisToChange)=> { axisToChange.MoveEast(); }},
            {Compass.SE, (axisToChange)=> { axisToChange.MoveSouthEast(); }},
            {Compass.S, (axisToChange)=> { axisToChange.MoveSouth(); }},
            {Compass.SW, (axisToChange)=> { axisToChange.MoveSouthWest(); }},
            {Compass.W, (axisToChange)=> { axisToChange.MoveWest(); }},
            {Compass.NW, (axisToChange)=> { axisToChange.MoveNorthWest(); }},
        };
        private readonly Dictionary<Compass, Compass> _goBackCompass = new Dictionary<Compass, Compass>
        {
            {Compass.N, Compass.S },
            {Compass.NE, Compass.SW },
            {Compass.E, Compass.W },
            {Compass.SE, Compass.NW },
            {Compass.S, Compass.N },
            {Compass.SW, Compass.NE },
            {Compass.W, Compass.E },
            {Compass.NW, Compass.SE },
        };
        private int _fuelToReturnHome;

        public AircraftManagement(int fuel, Axis axis)
        {
            _fuel = fuel;
            _axis = axis;
            CalculateFuelToReturnHome();
        }

        private void CalculateFuelToReturnHome()
        {
            _fuelToReturnHome = _fuel / 2 + _fuel % 2;
        }

        public void NavigateTo(Compass compass)
        {
            if (_fuel == empty) 
            {
                return;
            }

            if (_fuel > _fuelToReturnHome)
            {
                _navigateTo[compass](_axis);
                _fuel --;
                _wayBack.Add(_goBackCompass[compass]);
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
                _navigateTo[compass](_axis);
                _fuel--;
            }
        }
    }
}