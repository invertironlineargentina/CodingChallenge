using CodingChallenge.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Services
{
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

                Dictionary<string, decimal[]> keyValuePairs = new Dictionary<string, decimal[]>();

                foreach (var g in geometricForms)
                {
                    decimal area = g.CalculateArea();
                    decimal perimeter = g.CalculatePerimeter();
                    var pair = keyValuePairs.Where(x => x.Key == g.GetType().Name).FirstOrDefault();
                    if (pair.Key != null)
                    {
                        area += pair.Value[1];
                        perimeter += pair.Value[2];
                        keyValuePairs[pair.Key] = new decimal[] { (int)pair.Value[0] + 1, area, perimeter };
                        continue;
                    }
                    keyValuePairs.Add(g.GetType().Name, new decimal[] { 1, area, perimeter });
                }

                keyValuePairs.ToList().ForEach(kv => sb.Append(GetLine((int)kv.Value[0], kv.Value[1], kv.Value[2], kv.Key)));

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append($"{keyValuePairs.Sum(x => x.Value[0])} {Properties.Resources.Shapes} ");
                sb.Append($"{Properties.Resources.Perimeter} {keyValuePairs.Sum(x => x.Value[2]):#.##} ");
                sb.Append($"{Properties.Resources.Area} {keyValuePairs.Sum(x => x.Value[1]):#.##}");
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
