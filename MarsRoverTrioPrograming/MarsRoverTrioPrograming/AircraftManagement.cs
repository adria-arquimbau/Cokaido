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
        private int _highFuel;
        private readonly Dictionary<Compass,Compass> GoBackCompass ;
        const int empty = 0;
        
        public AircraftManagement(int fuel, Axis axis)
        {
            GoBackCompass = new Dictionary<Compass, Compass>
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
            //dictionary per methods
            _fuel = fuel;    
            _axis = axis;
            CalculateHalfOfTheFuelRounded(fuel);
        }

        public void NavigateTo(Compass compass)
        {
            if (_fuel > _highFuel)
            {
                _wayBack.Add(GoBackCompass[compass]);
            }
            
            if (_fuel == empty)
            {
                return;
            }

            if (compass == Compass.N )
            {
                _axis.MoveNorth();
                
            }
        
            if (compass == Compass.NE )
            {
                _axis.MoveNorthEast();
                
            }

            if (compass == Compass.E )
            {
                _axis.MoveEast();
               
            }
        
            if (compass == Compass.SE )
            {
                _axis.MoveSouthEast();
                
            }
        
            if (compass == Compass.S )
            {
                _axis.MoveSouth();
                
            }

            if (compass == Compass.SW )
            {
                _axis.MoveSouthWest();
                
            }
        
            if (compass == Compass.W)
            {
                _axis.MoveWest();
               
            }
        
            if (compass == Compass.NW )
            {
                _axis.MoveNorthWest();
                
            }
            _fuel --;
        }
        private void CalculateHalfOfTheFuelRounded(int fuel)
        {
            _highFuel = _fuel / 2 + fuel % 2;
        }    
        
    }
}