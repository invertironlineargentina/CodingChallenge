using CodingChallenge.Data.Interfaces;
using System;

namespace CodingChallenge.Data.Domain
{
    public class Circle : IGeometricForm
    {
        private decimal _radius { get; set; }

        public Circle(decimal radius)
        {
            _radius = radius;
        }

        public decimal CalculateArea() => (decimal)Math.PI * (_radius / 2) * (_radius / 2);

        public decimal CalculatePerimeter() => (decimal)Math.PI * _radius;
    }
}
