using CodingChallenge.Data.Domain.Forms;
using CodingChallenge.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge.Data.Service
{
    public class CalculateReport : ICalculateReport
    {
        public ResultForReport GetResults(List<GeometricForm> formsList)
        {
            var results = new ResultForReport();

            if (!formsList.Any())
                results.ListIsEmpty = true;
            else
            {
                results.ReportLinesList = new List<ReportLineByFigure>();
                var typesForms = Enum.GetValues(typeof(TypeForm)).Cast<TypeForm>().ToList();

                foreach (var typeForm in typesForms)
                {
                    if (formsList.Any(x => x.Type == typeForm))
                    {
                        var reportLine = new ReportLineByFigure();
                        reportLine.Type = typeForm;
                        reportLine.Results.Quantity = formsList.Where(x => x.Type == typeForm).Count();
                        formsList.Where(x => x.Type == typeForm).ToList()
                            .ForEach(x =>
                            {
                                reportLine.Results.AreaResult += x.CalculateArea();
                                reportLine.Results.PerimeterResult += x.CalculatePerimeter();
                            });
                        results.ReportLinesList.Add(reportLine);
                    }
                }
                results.TotalForms = formsList.Count();
                results.TotalAreas = results.ReportLinesList.Sum(line => line.Results.AreaResult);
                results.TotalPerimeters = results.ReportLinesList.Sum(line => line.Results.PerimeterResult);
            }

            return results;
        }
    }
}
