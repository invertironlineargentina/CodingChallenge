using CodingChallenge.Data.Classes;
using CodingChallenge.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data
{
    internal sealed class Cuadrado : IBuilder
    {
        private static Cuadrado _instancia = null;
        private decimal _lado;

        private int _cantidad = 0;
        private decimal _perimetroAcum = 0m;
        private decimal _areaAcum = 0m;

        public TipoForma TipoForma { get; set; }

        private Cuadrado () {
            TipoForma = TipoForma.Cuadrado;
        }

        public static Cuadrado GetInstancia(decimal lado)
        {
            if (_instancia == null)
            {
                _instancia = new Cuadrado();
            }

            _instancia._lado = lado;
            _instancia._cantidad++;

            return _instancia;
        }

        public decimal CalcularArea()
        {
            var area = _lado * _lado;
            _areaAcum += area;
            return area;    
        }

        public decimal CalcularPerimetro() 
        {
            var per = _lado * 4;
            _perimetroAcum += per;
            return per;
        }

        public string TraducirForma(Idioma idioma)
        {
            switch (idioma)
            {
                case Idioma.Castellano: return _cantidad > 1 ? "Cuadrados" : "Cuadrado";
                case Idioma.Italiano: return _cantidad > 1 ? "Piazze" : "Piazza";
                default: return _cantidad > 1 ? "Squares" : "Square";
            }
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
    }
}
