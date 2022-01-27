using System;

namespace CodingChallenge.Data.Domain.Forms
{
    public class Circle : GeometricForm
    {
        public decimal Radio { get; set; }

        #region Constructor
        public Circle(decimal _radio)
        {
            Id = 3;
            Name = "Circle";
            Type = TypeForm.Circle;
            Radio = _radio;
        }
        #endregion

        #region Methods
        public override decimal CalculateArea()
        {
            return (decimal)Math.PI * (Radio / 2) * (Radio / 2);
        }

        public override decimal CalculatePerimeter()
        {
            return (decimal)Math.PI * Radio;
        }
        #endregion
    }
}
