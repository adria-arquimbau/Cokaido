using System;
using System.Collections.Generic;

namespace MarsRoverTrioPrograming
{
    public class AircraftManagement
    {
        private int _fuel;
        private readonly Axis _axis;
        private readonly List<Compass> _wayBack = new List<Compass>();
        private readonly int _emptyFuel = 0;
        
        public AircraftManagement(int fuel, Axis axis)
        {
            _fuel = fuel;
            _axis = axis;
        }    
    
        public void NavigateTo(Compass compass)
        {
            
            if (compass == Compass.N && IsFuelPositive())
            {
                _axis.MoveNorth();
                DiscountFuel();
                SaveWayBack(Compass.S);
            }
            
            if (compass == Compass.NE && IsFuelPositive())
            {
                _axis.MoveNorthEast();
                DiscountFuel();
            }

            if (compass == Compass.E && IsFuelPositive())
            {
                _axis.MoveEast();
                DiscountFuel();
            }
            
            if (compass == Compass.SE && IsFuelPositive())
            {
                _axis.MoveSouthEast();
                DiscountFuel();
            }
            
            if (compass == Compass.S && IsFuelPositive())
            {
                _axis.MoveSouth();
                DiscountFuel();
            }

            if (compass == Compass.SW && IsFuelPositive())
            {
                _axis.MoveSouthWest();
                DiscountFuel();
            }
            
            if (compass == Compass.W && IsFuelPositive())
            {
                _axis.MoveWest();
                DiscountFuel();
            }
            
            if (compass == Compass.NW && IsFuelPositive())
            {
                _axis.MoveNorthWest();
                DiscountFuel();
            }
        }

        private void SaveWayBack(Compass compass)
        {
            _wayBack.Add(compass);
            GoToHome();
        }

        private void GoToHome()
        {
            if (_fuel == _emptyFuel)
            {
                AddOnePointFuelAndBackOfOneMovement();
            }
        }

        private void AddOnePointFuelAndBackOfOneMovement()
        {
            foreach (var compass in _wayBack)
            {
                _fuel++;
                NavigateTo(compass);
            }
        }

        private bool IsFuelPositive()
        {
            return _fuel > _emptyFuel;
        }

        private void DiscountFuel()
        {
            _fuel --;
        }
    }
}