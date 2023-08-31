using CodingChallenge.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    internal abstract class FormasBuilder : IBuilder
    {
        public TipoForma TipoForma => throw new NotImplementedException();

        public decimal CalcularArea()
        {
            throw new NotImplementedException();
        }

        public decimal CalcularPerimetro()
        {
            throw new NotImplementedException();
        }

        public string ObtenerLinea(Idioma idioma)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public string TraducirForma(Idioma idioma)
        {
            throw new NotImplementedException();
        }
    }
}
