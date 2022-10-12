using CodingChallenge.Data.Domain.Enum;
using CodingChallenge.Data.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace CodingChallenge.Data.Services
{
    public class PrintSpanish : GeneratePrint
    {
        private readonly string _language = Language.Spanish;

        public PrintSpanish()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(_language);
        }
    }


}
