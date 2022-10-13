using CodingChallenge.Data.Domain.Enum;
using CodingChallenge.Data.Interfaces;
using System.Globalization;
using System.Threading;

namespace CodingChallenge.Data.Services
{
    public class PrintPortuguese : BasePrint, IPrint
    {
        private readonly string _language = Language.Portuguese;
        public PrintPortuguese() => Thread.CurrentThread.CurrentUICulture = new CultureInfo(_language);
    }
}
