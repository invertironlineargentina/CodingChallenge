using CodingChallenge.Data.Domain.Forms;
using CodingChallenge.Data.Helpers;

namespace CodingChallenge.Data.Domain.Idioms
{
    public class Spanish : Idiom
    {
        #region Constructor
        public Spanish()
        {
            Id = 1;
            Name = "Spanish";
            Type = TypeIdiom.Spanish;
        }
        #endregion

        #region Methods
        public override string EmptyListText()
        {
            return "Lista vacía de formas!";
        }

        public override string FooterText(ResultForReport resultForReport)
        {
            return $"TOTAL: {resultForReport.TotalForms} " + (resultForReport.TotalForms == 1 ? "forma" : "formas") + $" Perimetro {resultForReport.TotalPerimeters:#.##} Area {resultForReport.TotalAreas:#.##}";
        }

        public override string HeaderText()
        {
            return "Reporte de Formas!";
        }

        public override string LineText(ReportLineByFigure line)
        {
            return $"{line.Results.Quantity} {TranslateForm(line.Type, line.Results.Quantity)} | Area {line.Results.AreaResult:#.##} | Perimetro {line.Results.PerimeterResult:#.##}";
        }

        public override string TranslateForm(TypeForm typeForm, int quantity)
        {
            switch (typeForm)
            {
                case TypeForm.Square:  //  Cuadrado
                    return (quantity == 1 ? "Cuadrado" : "Cuadrados");
                case TypeForm.EquilateralTriangle:  //  TrianguloEquilatero
                    return (quantity == 1 ? "Triángulos Equilatero" : "Triángulos Equilateros");
                case TypeForm.Circle:  //  Circulo
                    return (quantity == 1 ? "Círculo" : "Círculos");
                case TypeForm.Trapeze:  //  Trapecio
                    return (quantity == 1 ? "Trapecio" : "Trapecios");
                case TypeForm.Rectangle:  //  Rectangulo
                    return (quantity == 1 ? "Rectangulo" : "Rectangulos");
                default:
                    return "figura no definida en el Idioma Español.";
            }
        }
        #endregion
    }
}
