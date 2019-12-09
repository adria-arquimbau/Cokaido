using System.Collections.Generic;
using System.Reflection;
using MarsRoverTrioPrograming.Tests;
using Xunit.Abstractions;

namespace MarsRoverTrioPrograming
{
    public class FlightMode : IPosition
    {
        private readonly Direction _direction;
        private readonly Axis _axis;
        private AircraftManagement _aircraftManagement;

        public FlightMode(int fuel, Compass direction = Compass.N, int positionY = 0, int positionX = 0)    
        {
            _axis = new Axis(positionY, positionX);
            _direction = new Direction(direction);
            _aircraftManagement = new AircraftManagement(fuel, _axis);   
        }    
    
        public override string ToString()
        {
            return $"{_axis}:{_direction}";
        }    
    
        public void Move()
        {
            if (Equals(_direction, new Direction(Compass.N)))
            {
                _aircraftManagement.NavigateTo(Compass.N);
            }

            if (Equals(_direction, new Direction(Compass.NE)))
            {
                _aircraftManagement.NavigateTo(Compass.NE);
            }

            if (Equals(_direction, new Direction(Compass.E)))
            {
                _aircraftManagement.NavigateTo(Compass.E);
            }

            if (Equals(_direction, new Direction(Compass.SE)))
            {
                _aircraftManagement.NavigateTo(Compass.SE);
            }
                
            if (Equals(_direction, new Direction(Compass.S)))
            {
                _aircraftManagement.NavigateTo(Compass.S);
            }

            if (Equals(_direction, new Direction(Compass.SW)))
            {
                _aircraftManagement.NavigateTo(Compass.SW);
            }

            if (Equals(_direction, new Direction(Compass.W)))
            {
                _aircraftManagement.NavigateTo(Compass.W);
            }

            if (Equals(_direction, new Direction(Compass.NW)))
            {
                _aircraftManagement.NavigateTo(Compass.NW);
            }   
        }

        public void TurnRight() 
        {
            _direction.TurnRight();
        }

        public void TurnLeft()
        {
            _direction.TurnLeft();
        }
    }
}       