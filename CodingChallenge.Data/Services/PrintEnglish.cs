using CodingChallenge.Data.Domain.Enum;
using CodingChallenge.Data.Interfaces;
using System.Globalization;
using System.Threading;

namespace CodingChallenge.Data.Services
{
    public class PrintEnglish : BasePrint, IPrint
    {
        private readonly string _language = Language.English;
        public PrintEnglish() => Thread.CurrentThread.CurrentUICulture = new CultureInfo(_language);
    }
}
