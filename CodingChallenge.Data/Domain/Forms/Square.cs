
namespace CodingChallenge.Data.Domain.Forms
{
    public class Square : GeometricForm
    {
        public decimal Side { get; set; }

        #region Constructor
        public Square(decimal side)
        {
            Id = 1;
            Name = "Square";
            Type = TypeForm.Square;
            Side = side;
        }
        #endregion

        #region Methods
        public override decimal CalculateArea()
        {
            return Side * Side;
        }

        public override decimal CalculatePerimeter()
        {
            return Side * 4;
        }
        #endregion
    }
}
