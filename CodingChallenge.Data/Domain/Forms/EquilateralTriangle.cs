using System;

namespace CodingChallenge.Data.Domain.Forms
{
    public class EquilateralTriangle : GeometricForm
    {
        public decimal Side { get; set; }

        #region Constructor
        public EquilateralTriangle(decimal side)
        {
            Id = 2;
            Name = "Equilateral Triangle";
            Type = TypeForm.EquilateralTriangle;
            Side = side;
        }
        #endregion

        #region Methods
        public override decimal CalculateArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * Side * Side;
        }

        public override decimal CalculatePerimeter()
        {
            return Side * 3;
        }
        #endregion
    }
}
