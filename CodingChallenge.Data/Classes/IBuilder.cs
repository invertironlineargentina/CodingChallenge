using CodingChallenge.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    internal interface IBuilder
    {
        // TODO ver si se deben implementar cantidad, perimetro y area
        TipoForma TipoForma { get; }
        void Reset();
        decimal CalcularPerimetro();
        decimal CalcularArea();
        string TraducirForma(Idioma idioma);
        string ObtenerLinea(Idioma idioma);
    }
}
