using CodingChallenge.Data.Interfaces;

namespace CodingChallenge.Data.Domain
{
    public class Rectangle : IGeometricForm
    {
        private decimal _ladoA { get; set; }
        private decimal _ladoB { get; set; }

        public Rectangle(decimal ladoA, decimal ladoB)
        {
            _ladoA = ladoA;
            _ladoB = ladoB;
        }

        public decimal CalculateArea() => _ladoA * _ladoB;

        public decimal CalculatePerimeter() => 2 * (_ladoA + _ladoB);
    }
}
