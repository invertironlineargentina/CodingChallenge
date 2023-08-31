using CodingChallenge.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public abstract class FormasBuilder : IFormasBuilder
    {
        internal int _cantidad = 0;
        internal decimal _perimetroAcum = 0m;
        internal decimal _areaAcum = 0m;
        public TipoForma TipoForma { get; set; }

        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();
        public abstract string TraducirForma(Idioma idioma);

        public string ObtenerLinea(Idioma idioma)
        {
            if (_cantidad == 0) return string.Empty;

            if (idioma == Idioma.Ingles)
                return $"{_cantidad} {TraducirForma(idioma)} | Area {_areaAcum:#.##} | Perimeter {_perimetroAcum:#.##} <br/>";
            else
                return $"{_cantidad} {TraducirForma(idioma)} | Area {_areaAcum:#.##} | Perimetro {_perimetroAcum:#.##} <br/>";

        }

        public void Reset()
        {
            _cantidad = 0;
            _perimetroAcum = 0m;
            _areaAcum = 0m;
        }
    }
}
