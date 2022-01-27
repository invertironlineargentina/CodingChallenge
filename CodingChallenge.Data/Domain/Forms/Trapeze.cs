using System;

namespace CodingChallenge.Data.Domain.Forms
{
    public class Trapeze : GeometricForm
    {
        public decimal HighBase { get; set; }
        public decimal MinorBase { get; set; }
        public decimal SideC { get; set; }
        public decimal SideD { get; set; }


        #region Constructor
        public Trapeze(decimal highBase, decimal minorBase, decimal sideC, decimal sideD)
        {
            Id = 4;
            Name = "Trapeze";
            Type = TypeForm.Trapeze;
            HighBase = highBase;
            MinorBase = minorBase;
            SideC = sideC;
            SideD = sideD;
        }
        #endregion

        #region Methods
        public override decimal CalculateArea()
        {
            double a = (double)HighBase;
            double b = (double)MinorBase;
            double c = (double)SideC;
            double d = (double)SideD;
            double helper = (Math.Pow(c, 2) - Math.Pow(d, 2) + Math.Pow((a - b), 2)) / (2 * (a - b));
            double total = (a + b) / 2 * Math.Sqrt(Math.Pow(c, 2) - Math.Pow(helper, 2));
            return (decimal)total;
        }

        public override decimal CalculatePerimeter()
        {
            return HighBase + MinorBase + SideC + SideD;
        }
        #endregion
    }
}
