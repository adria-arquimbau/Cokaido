using System;
using System.Collections.Generic;

namespace MarsRoverTrioPrograming
{
    public class AircraftManagement
    {
        private int _fuel;
        private readonly Axis _axis;
        private readonly List<Compass> _wayBack = new List<Compass>();
        private int _highFuel;
        
        public AircraftManagement(int fuel, Axis axis)
        {
            _fuel = fuel;    
            _axis = axis;
            GetHighFuel(fuel);
        }

        public void NavigateTo(Compass compass)
        {
            if (_fuel > _highFuel)
            {
                if (compass == Compass.N )
                {
                    _axis.MoveNorth();
                    _fuel --;
                }
            
                if (compass == Compass.NE )
                {
                    _axis.MoveNorthEast();
                    _fuel --;
                }

                if (compass == Compass.E )
                {
                    _axis.MoveEast();
                    _fuel --;
                }
            
                if (compass == Compass.SE )
                {
                    _axis.MoveSouthEast();
                    _fuel --;
                }
            
                if (compass == Compass.S )
                {
                    _axis.MoveSouth();
                    _fuel --;
                }

                if (compass == Compass.SW )
                {
                    _axis.MoveSouthWest();
                    _fuel --;
                }
            
                if (compass == Compass.W)
                {
                    _axis.MoveWest();
                    _fuel --;
                }
            
                if (compass == Compass.NW )
                {
                    _axis.MoveNorthWest();
                    _fuel --;
                }
            }
        }
        private void GetHighFuel(int fuel)
        {
            _highFuel = _fuel / 2 + fuel % 2;
        }
        
    }
}