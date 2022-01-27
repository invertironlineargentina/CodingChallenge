
using CodingChallenge.Data.Domain.Forms;
using CodingChallenge.Data.Helpers;

namespace CodingChallenge.Data.Domain.Idioms
{
    public class French : Idiom
    {
        #region Constructor
        public French()
        {
            Id = 3;
            Name = "French";
            Type = TypeIdiom.French;
        }
        #endregion

        #region Methods
        public override string EmptyListText()
        {
            return "Liste vide de formes!";
        }

        public override string FooterText(ResultForReport resultForReport)
        {
            return $"TOTAL: {resultForReport.TotalForms} " + (resultForReport.TotalForms == 1 ? "forme" : "des formes") + $" Périmètre {resultForReport.TotalPerimeters:#.##} Zone {resultForReport.TotalAreas:#.##}";
        }

        public override string HeaderText()
        {
            return "Rapport de formes!";
        }

        public override string LineText(ReportLineByFigure line)
        {
            return $"{line.Results.Quantity} {TranslateForm(line.Type, line.Results.Quantity)} | Zone {line.Results.AreaResult:#.##} | Périmètre {line.Results.PerimeterResult:#.##}";
        }

        public override string TranslateForm(TypeForm typeForm, int quantity)
        {
            switch (typeForm)
            {
                case TypeForm.Square:  //  Cuadrado
                    return (quantity == 1 ? "Carré" : "Des Carrés");
                case TypeForm.EquilateralTriangle:  //  TrianguloEquilatero
                    return (quantity == 1 ? "Triangle équilatéral" : "Triangles équilatéraux");
                case TypeForm.Circle:  //  Circulo
                    return (quantity == 1 ? "Cercle" : "Cercles");
                case TypeForm.Trapeze:  //  Trapecio
                    return (quantity == 1 ? "Trapèze" : "Trapèzes");
                case TypeForm.Rectangle:  //  Rectangulo
                    return (quantity == 1 ? "Rectangle" : "Des Rectangles");
                default:
                    return "chiffre non défini en langue française.";
            }
        }
        #endregion
    }
}
