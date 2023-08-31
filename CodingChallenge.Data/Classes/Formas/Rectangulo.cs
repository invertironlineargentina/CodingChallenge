using CodingChallenge.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Formas
{
    internal class Rectangulo : IBuilder
    {
        private static Rectangulo _instancia = null;
        private decimal _lado;
        private decimal _ancho;

        private int _cantidad = 0;
        private decimal _perimetroAcum = 0m;
        private decimal _areaAcum = 0m;

        public TipoForma TipoForma { get; set; }

        private Rectangulo() 
        {
            TipoForma = TipoForma.Rectangulo;
        }

        public static Rectangulo GetInstancia(decimal lado, decimal ancho)
        {
            if (_instancia == null)
            {
                _instancia = new Rectangulo();
            }

            _instancia._lado = lado;
            _instancia._ancho = ancho;
            _instancia._cantidad++;

            return _instancia;
        }

        public decimal CalcularArea()
        {
            var area = _lado * _ancho;
            _areaAcum += area;
            return area;
        }

        public decimal CalcularPerimetro()
        {
            var per = 2*_lado + 2*_ancho;
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
                case Idioma.Castellano: return _cantidad > 1 ? "Rectángulos" : "Rectángulo";
                case Idioma.Italiano: return _cantidad > 1 ? "Rettangoli" : "Rettangolo";
                default: return _cantidad > 1 ? "Rectangles" : "Rectangles";
            }
        }
    }
}
