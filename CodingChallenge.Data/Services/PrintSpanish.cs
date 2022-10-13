using CodingChallenge.Data.Domain.Enum;
using CodingChallenge.Data.Interfaces;
using System.Globalization;
using System.Threading;

namespace CodingChallenge.Data.Services
{
    public class PrintSpanish : BasePrint, IPrint
    {
        private readonly string _language = Language.Spanish;
        public PrintSpanish() => Thread.CurrentThread.CurrentUICulture = new CultureInfo(_language);
    }
}
