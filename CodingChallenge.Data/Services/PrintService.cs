using CodingChallenge.Data.Interfaces;
using System.Collections.Generic;

namespace CodingChallenge.Data.Services
{
    public class PrintService
    {
        private readonly IPrint _print;
        public PrintService(IPrint print)
        {
            _print = print;
        }

        public string Print(IList<IGeometricForm> geometricForms) => _print.CreatePrint(geometricForms);
    }
}
