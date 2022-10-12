using CodingChallenge.Data.Domain.Enum;
using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace CodingChallenge.Data.Services
{
    public class PrintEnglish : IPrint
    {
        private readonly string _language = Language.English;
        public string CreatePrint(IList<IGeometricForm> geometricForms)
        {
            throw new NotImplementedException();
        }
    }
}
