using CodingChallenge.Data.Domain.Enum;
using CodingChallenge.Data.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace CodingChallenge.Data.Services
{
    public class PrintSpanish : IPrint
    {
        private readonly string _language = Language.Spanish;

        public PrintSpanish()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(_language);
        }

        public string CreatePrint(IList<IGeometricForm> geometricForms)
        {
            var sb = new StringBuilder();

            if (!geometricForms.Any())
            {
                sb.Append("<h1>Lista vacía de formas!</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                sb.Append("<h1>Reporte de Formas</h1>");

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
                foreach (var kv in keyValuePairs) {
                    total += (int)kv.Value[0];
                    totalA += kv.Value[1];
                    totalP += kv.Value[2];
                    sb.Append(GetLine((int)kv.Value[0], kv.Value[1], kv.Value[2], kv.Key));
                }

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(total + " formas");
                sb.Append("Perimetro " + totalA.ToString("#.##") + " ");
                sb.Append("Area " + totalP.ToString("#.##"));
            }

            return sb.ToString();
        }


        private static string GetLine( int count, decimal area, decimal perimeter, string type)
        {
            if (count > 0)
            {
                return $"{count} {TranslateForm(type, count)} | Area {area:#.##} | Perimetro {perimeter:#.##} <br/>";
            }

            return string.Empty;
        }

        private static string TranslateForm(string type, int count)
        {
            //string resVal = ResourceManager.GetString(type);
            //switch (tipo)
            //{
            //    case Cuadrado:
            //        if (idioma == Castellano) return cantidad == 1 ? "Cuadrado" : "Cuadrados";
            //        else return cantidad == 1 ? "Square" : "Squares";
            //    case Circulo:
            //        if (idioma == Castellano) return cantidad == 1 ? "Círculo" : "Círculos";
            //        else return cantidad == 1 ? "Circle" : "Circles";
            //    case TrianguloEquilatero:
            //        if (idioma == Castellano) return cantidad == 1 ? "Triángulo" : "Triángulos";
            //        else return cantidad == 1 ? "Triangle" : "Triangles";
            //}

            return string.Empty;
        }

    }


}
