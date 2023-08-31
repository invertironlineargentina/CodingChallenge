using CodingChallenge.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Formas
{
    internal class Circulo : IBuilder
    {
        private static Circulo _instancia = null;
        private decimal _lado;

        private int _cantidad = 0;
        private decimal _perimetroAcum = 0m;
        private decimal _areaAcum = 0m;

        public TipoForma TipoForma { get; set; }

        private Circulo()
        {
            TipoForma = TipoForma.Circulo;
        }

        public static Circulo GetInstancia(decimal lado)
        {
            if (_instancia == null)
            {
                _instancia = new Circulo();
            }

            _instancia._lado = lado;
            _instancia._cantidad++;

            return _instancia;
        }

        public decimal CalcularArea()
        {
            var area = (decimal)Math.PI * (_lado / 2) * (_lado / 2);
            _areaAcum += area;
            return area;
        }

        public decimal CalcularPerimetro()
        {
            var per = (decimal)Math.PI * _lado;
            _perimetroAcum += per;
            return per;
        }

        public string ObtenerLinea(Idioma idioma)
        {
            // TODO agregar italiano
            if (_cantidad > 0)
            {
                if (idioma == Idioma.Castellano)
                    return $"{_cantidad} {TraducirForma(idioma)} | Area {_areaAcum:#.##} | Perimetro {_perimetroAcum:#.##} <br/>";

                return $"{_cantidad} {TraducirForma(idioma)} | Area {_areaAcum:#.##} | Perimeter {_perimetroAcum:#.##} <br/>";
            }

            return string.Empty;
        }

        public void Reset()
        {
            _cantidad = 0;
            _perimetroAcum = 0m;
            _areaAcum = 0m;
        }

        public string TraducirForma(Idioma idioma)
        {
            switch (idioma)
            {
                case Idioma.Castellano: return _cantidad > 1 ? "Círculos" : "Círculo";
                case Idioma.Italiano: return _cantidad > 1 ? "Cerchi" : "Cerchio";
                default: return _cantidad > 1 ? "Circles" : "Circle";
            }
        }
    }
}
