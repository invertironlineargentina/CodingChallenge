using CodingChallenge.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Services
{
    public abstract class GeneratePrint : IPrint
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

                Dictionary<string, decimal[]> keyValuePairs = new Dictionary<string, decimal[]>();

                foreach (var g in geometricForms)
                {
                    decimal area = g.CalculateArea();
                    decimal perimeter = g.CalculatePerimeter();
                    int count = 1;
                    if (keyValuePairs.Any(x => x.Key == g.GetType().Name))
                    {
                        var pair = keyValuePairs.Where(x => x.Key == g.GetType().Name).FirstOrDefault();
                        count = (int)pair.Value[0] + 1;
                        area += pair.Value[1];
                        perimeter += pair.Value[2];
                        keyValuePairs[pair.Key] = new decimal[] { count, area, perimeter };
                        continue;
                    }
                    keyValuePairs.Add(g.GetType().Name, new decimal[] { count, area, perimeter });
                }
                int total = 0;
                decimal totalA = 0;
                decimal totalP = 0;
                foreach (var kv in keyValuePairs)
                {
                    total += (int)kv.Value[0];
                    totalA += kv.Value[1];
                    totalP += kv.Value[2];
                    sb.Append(GetLine((int)kv.Value[0], kv.Value[1], kv.Value[2], kv.Key));
                }

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append($"{total} {Properties.Resources.Shapes} ");
                sb.Append($"{Properties.Resources.Perimeter} {totalP.ToString("#.##")} ");
                sb.Append($"{Properties.Resources.Area} {totalA.ToString("#.##")}");
            }

            return sb.ToString();
        }


        private static string GetLine(int count, decimal area, decimal perimeter, string type)
        {
            if (count > 0)
            {
                return $"{count} {TranslateForm(type, count)} | {Properties.Resources.Area} {area:#.##} | {Properties.Resources.Perimeter} {perimeter:#.##} <br/>";
            }

            return string.Empty;
        }

        private static string TranslateForm(string type, int count)
        {
            string single = Properties.Resources.ResourceManager.GetString(type);
            string plural = Properties.Resources.ResourceManager.GetString(type + "Plural");
            return count == 1 ? single : plural;
        }
    }
}
