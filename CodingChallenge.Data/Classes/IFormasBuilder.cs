using CodingChallenge.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    internal interface IFormasBuilder
    {
        TipoForma TipoForma { get; }
        void Reset();
        decimal CalcularPerimetro();
        decimal CalcularArea();
        string TraducirForma(Idioma idioma);
        string ObtenerLinea(Idioma idioma);
    }
}
