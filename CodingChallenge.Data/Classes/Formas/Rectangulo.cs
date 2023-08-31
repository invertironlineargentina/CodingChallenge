using CodingChallenge.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Formas
{
    internal class Rectangulo : FormasBuilder
    {
        private static Rectangulo _instancia = null;
        private decimal _alto;
        private decimal _ancho;

        private Rectangulo() 
        {
            TipoForma = TipoForma.Rectangulo;
        }

        public static Rectangulo GetInstancia(decimal alto, decimal ancho)
        {
            if (_instancia == null)
            {
                _instancia = new Rectangulo();
            }

            _instancia._alto = alto;
            _instancia._ancho = ancho;
            _instancia._cantidad++;

            return _instancia;
        }

        public override decimal CalcularArea()
        {
            var area = _alto * _ancho;
            _areaAcum += area;
            return area;
        }

        public override decimal CalcularPerimetro()
        {
            var per = 2 * _alto + 2 * _ancho;
            _perimetroAcum += per;
            return per;
        }

        public override string TraducirForma(Idioma idioma)
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
