using CodingChallenge.Data.Domain.Forms;
using CodingChallenge.Data.Helpers;

namespace CodingChallenge.Data.Domain.Idioms
{
    public abstract class Idiom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeIdiom Type { get; set; }

        public abstract string HeaderText();
        public abstract string EmptyListText();
        public abstract string LineText(ReportLineByFigure line);
        public abstract string TranslateForm(TypeForm typeForm, int quantity);
        public abstract string FooterText(ResultForReport resultForReport);
    }
}
