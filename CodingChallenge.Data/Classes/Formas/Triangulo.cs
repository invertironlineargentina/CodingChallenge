using CodingChallenge.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Formas
{
    internal class Triangulo : IBuilder
    {
        private static Triangulo _instancia = null;
        private decimal _lado;
        private decimal _ancho;

        private int _cantidad = 0;
        private decimal _perimetroAcum = 0m;
        private decimal _areaAcum = 0m;

        public TipoForma TipoForma { get; set; }

        private Triangulo()
        {
            TipoForma = TipoForma.TrianguloEquilatero;
        }

        public static Triangulo GetInstancia(decimal lado)
        {
            if (_instancia == null)
            {
                _instancia = new Triangulo();
            }

            _instancia._lado = lado;
            _instancia._cantidad++;

            return _instancia;
        }

        public decimal CalcularArea()
        {
            var area = ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
            _areaAcum += area;
            return area;
        }

        public decimal CalcularPerimetro()
        {
            var per = _lado * 3;
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
                case Idioma.Castellano: return _cantidad > 1 ? "Triángulos" : "Triángulo";
                case Idioma.Italiano: return _cantidad > 1 ? "Triangolo" : "Triangoli";
                default: return _cantidad > 1 ? "Triangles" : "Triangles";
            }
        }
    }
}
