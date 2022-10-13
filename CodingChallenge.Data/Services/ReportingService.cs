using CodingChallenge.Data.Interfaces;
using System.Collections.Generic;

namespace CodingChallenge.Data.Services
{
    public class ReportingService : IReportingService
    {
        private readonly IPrint _print;
        public ReportingService(IPrint print)
        {
            _print = print;
        }

        public string OtherMethod(IList<IGeometricForm> geometricForms)
        {
            throw new System.NotImplementedException();
        }

        public string Print(IList<IGeometricForm> geometricForms) => _print.CreatePrint(geometricForms);
    }
}
