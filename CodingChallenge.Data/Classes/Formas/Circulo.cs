using CodingChallenge.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Formas
{
    internal class Circulo : FormasBuilder
    {
        private static Circulo _instancia = null;
        private decimal _diametro;

        private Circulo()
        {
            TipoForma = TipoForma.Circulo;
        }

        public static Circulo GetInstancia(decimal diametro)
        {
            if (_instancia == null)
            {
                _instancia = new Circulo();
            }

            _instancia._diametro = diametro;
            _instancia._cantidad++;

            return _instancia;
        }

        public override decimal CalcularArea()
        {
            var area = (decimal)Math.PI * (_diametro / 2) * (_diametro / 2);
            _areaAcum += area;
            return area;
        }

        public override decimal CalcularPerimetro()
        {
            var per = (decimal)Math.PI * _diametro;
            _perimetroAcum += per;
            return per;
        }

        public override string TraducirForma(Idioma idioma)
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
