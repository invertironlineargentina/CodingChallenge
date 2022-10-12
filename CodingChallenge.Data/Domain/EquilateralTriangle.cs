using CodingChallenge.Data.Interfaces;
using System;

namespace CodingChallenge.Data.Domain
{
    public class EquilateralTriangle : IGeometricForm
    {
        private decimal _lado { get; set; }

        public EquilateralTriangle(decimal lado)
        {
            _lado = lado;
        }

        public decimal CalculateArea() => ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;

        public decimal CalculatePerimeter() => _lado * 3;
    }
}
