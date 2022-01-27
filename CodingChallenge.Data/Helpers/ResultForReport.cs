using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Helpers
{
    public class ResultForReport
    {
        public bool ListIsEmpty { get; set; }
        public List<ReportLineByFigure> ReportLinesList { get; set; }
        public int TotalForms { get; set; }
        public decimal TotalAreas { get; set; }
        public decimal TotalPerimeters { get; set; }
    }
}
