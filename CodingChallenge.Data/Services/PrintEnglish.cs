using CodingChallenge.Data.Domain.Enum;
using System.Globalization;
using System.Threading;

namespace CodingChallenge.Data.Services
{
    public class PrintEnglish : GeneratePrint
    {
        private readonly string _language = Language.English;

        public PrintEnglish() => Thread.CurrentThread.CurrentCulture = new CultureInfo(_language);
    }
}
