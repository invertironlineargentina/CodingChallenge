using CodingChallenge.Data.Domain.Enum;
using CodingChallenge.Data.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace CodingChallenge.Data.Services
{
    public class PrintEnglish : GeneratePrint
    {
        private readonly string _language = Language.English;

        public PrintEnglish()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(_language);
        }
    }
}
