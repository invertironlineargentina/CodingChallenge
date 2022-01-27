
using CodingChallenge.Data.Domain.Forms;
using CodingChallenge.Data.Helpers;

namespace CodingChallenge.Data.Domain.Idioms
{
    public class English : Idiom
    {
        #region Constructor
        public English()
        {
            Id = 2;
            Name = "English";
            Type = TypeIdiom.English;
        }
        #endregion

        #region Methods
        public override string EmptyListText()
        {
            return "Empty list of shapes!";
        }

        public override string FooterText(ResultForReport resultForReport)
        {
            return $"TOTAL: {resultForReport.TotalForms} " + (resultForReport.TotalForms == 1 ? "shape" : "shapes") + $" Perimeter {resultForReport.TotalPerimeters:#.##} Area {resultForReport.TotalAreas:#.##}";
        }

        public override string HeaderText()
        {
            return "Shapes report!";
        }

        public override string LineText(ReportLineByFigure line)
        {
            return $"{line.Results.Quantity} {TranslateForm(line.Type, line.Results.Quantity)} | Area {line.Results.AreaResult:#.##} | Perimeter {line.Results.PerimeterResult:#.##}";
        }

        public override string TranslateForm(TypeForm typeForm, int quantity)
        {
            switch (typeForm)
            {
                case TypeForm.Square:  //  Cuadrado
                    return (quantity == 1 ? "Square" : "Squares");
                case TypeForm.EquilateralTriangle:  //  TrianguloEquilatero
                    return (quantity == 1 ? "Equilateral Triangle" : "Equilateral Triangles");
                case TypeForm.Circle:  //  Circulo
                    return (quantity == 1 ? "Circle" : "Circles");
                case TypeForm.Trapeze:  //  Trapecio
                    return (quantity == 1 ? "Trapeze" : "Trapezes");
                case TypeForm.Rectangle:  //  Rectangulo
                    return (quantity == 1 ? "Rectangle" : "Rectangles");
                default:
                    return "Figure not defined in the English Language.";
            }
        }
        #endregion
    }
}
