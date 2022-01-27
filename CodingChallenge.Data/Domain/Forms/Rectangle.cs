
namespace CodingChallenge.Data.Domain.Forms
{
    public class Rectangle : GeometricForm
    {
        public decimal Base { get; set; }
        public decimal Height { get; set; }

        #region Constructor
        public Rectangle(decimal _base, decimal height)
        {
            Id = 5;
            Name = "Rectangle";
            Type = TypeForm.Rectangle;
            Base = _base;
            Height = height;
        }
        #endregion

        #region Methods
        public override decimal CalculateArea()
        {
            return Base * Height;
        }

        public override decimal CalculatePerimeter()
        {
            return Base * 2 + Height * 2;
        }
        #endregion
    }
}
