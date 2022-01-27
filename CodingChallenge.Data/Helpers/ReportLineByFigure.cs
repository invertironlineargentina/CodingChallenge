
using CodingChallenge.Data.Domain.Forms;

namespace CodingChallenge.Data.Helpers
{
    public class ReportLineByFigure
    {
        public TypeForm Type{ get; set; }
        public FigureResults Results { get; set; }

        public ReportLineByFigure()
        {
            Results = new FigureResults();
        }
    }
}
