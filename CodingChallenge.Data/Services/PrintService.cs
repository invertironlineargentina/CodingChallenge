using CodingChallenge.Data.Domain;
using CodingChallenge.Data.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Data.Services
{
    public class PrintService
    {
        private readonly IPrint _print;
        public PrintService(IPrint print)
        {
            _print = print;
        }

        public string Print(IList<IGeometricForm> geometricForms) {
            return _print.CreatePrint(geometricForms);
        }
    }
}
