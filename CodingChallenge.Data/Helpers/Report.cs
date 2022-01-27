/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using CodingChallenge.Data.Domain.Forms;
using CodingChallenge.Data.Domain.Idioms;
using CodingChallenge.Data.Service;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Data.Helpers
{
    public class Report
    {
        public static string Print(List<GeometricForm> formsList, Idiom idiom, ICalculateReport _service)
        {
            var reportText = new StringBuilder();
            var results = _service.GetResults(formsList);

            if (results.ListIsEmpty)
                reportText.Append("<h1>" + idiom.EmptyListText() + "</h1>");
            else
            {
                reportText.Append("<h1>" + idiom.HeaderText() + "</h1>");

                foreach (var line in results.ReportLinesList)
                    reportText.Append("<br>" + idiom.LineText(line));

                reportText.Append("<br>" + idiom.FooterText(results));
            }

            return reportText.ToString();
        }
    }
}
