using CodingChallenge.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Services
{
    public class ReportGeometricForm
    {
        public int Count { get; set; } = 1;
        public decimal Area { get; set; }
        public decimal Perimeter { get; set; }
        public string Type { get; set; }
    }
    public abstract class BasePrint
    {
        public string CreatePrint(IList<IGeometricForm> geometricForms)
        {
            var sb = new StringBuilder();

            if (!geometricForms.Any())
            {
                sb.Append(Properties.Resources.ListEmpty);
            }
            else
            {
                // HEADER
                sb.Append(Properties.Resources.Header);

                IList<ReportGeometricForm> reportGeometricForms = new List<ReportGeometricForm>();

                foreach (var g in geometricForms)
                {
                    decimal area = g.CalculateArea();
                    decimal perimeter = g.CalculatePerimeter();

                    var r = reportGeometricForms.FirstOrDefault(x => x.Type == g.GetType().Name);
                    if (r != null)
                    {
                        var i = reportGeometricForms.IndexOf(r);
                        reportGeometricForms[i].Area += area;
                        reportGeometricForms[i].Perimeter += perimeter;
                        reportGeometricForms[i].Count++;
                        continue;
                    }
                    reportGeometricForms.Add(new ReportGeometricForm()
                    {
                        Type = g.GetType().Name,
                        Area = area,
                        Perimeter = perimeter
                    });
                }

                reportGeometricForms.ToList().ForEach(x => sb.Append(GetLine(x.Count, x.Area, x.Perimeter, x.Type)));

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append($"{reportGeometricForms.Sum(x => x.Count)} {Properties.Resources.Shapes} ");
                sb.Append($"{Properties.Resources.Perimeter} {reportGeometricForms.Sum(x => x.Perimeter):#.##} ");
                sb.Append($"{Properties.Resources.Area} {reportGeometricForms.Sum(x => x.Area):#.##}");
            }

            return sb.ToString();
        }

        private string GetLine(int count, decimal area, decimal perimeter, string type)
        {
            if (count > 0)
            {
                return $"{count} {TranslateForm(type, count)} | {Properties.Resources.Area} {area:#.##} | {Properties.Resources.Perimeter} {perimeter:#.##} <br/>";
            }

            return string.Empty;
        }

        private string TranslateForm(string type, int count)
        {
            string single = Properties.Resources.ResourceManager.GetString(type);
            string plural = Properties.Resources.ResourceManager.GetString(type + "Plural");
            return count == 1 ? single : plural;
        }
    }
}
