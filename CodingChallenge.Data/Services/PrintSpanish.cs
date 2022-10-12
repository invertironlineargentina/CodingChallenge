using CodingChallenge.Data.Domain.Enum;
using System.Globalization;
using System.Threading;

namespace CodingChallenge.Data.Services
{
    public class PrintSpanish : GeneratePrint
    {
        private readonly string _language = Language.Spanish;
        public PrintSpanish() => Thread.CurrentThread.CurrentCulture = new CultureInfo(_language);
    }
}
