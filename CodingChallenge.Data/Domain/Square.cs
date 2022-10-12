using CodingChallenge.Data.Interfaces;

namespace CodingChallenge.Data.Domain
{
    public class Square : IGeometricForm
    {
        private decimal _lado { get; set; }

        public Square(decimal lado)
        {
            _lado = lado;
        }

        public decimal CalculateArea() => _lado * _lado;

        public decimal CalculatePerimeter() => _lado * 4;
    }
}
