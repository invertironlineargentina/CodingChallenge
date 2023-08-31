using CodingChallenge.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Formas
{
    internal class Triangulo : FormasBuilder
    {
        private static Triangulo _instancia = null;
        private decimal _lado;


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

        public override decimal CalcularArea()
        {
            var area = ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
            _areaAcum += area;
            return area;
        }

        public override decimal CalcularPerimetro()
        {
            var per = _lado * 3;
            _perimetroAcum += per;
            return per;
        }

        public override string TraducirForma(Idioma idioma)
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
