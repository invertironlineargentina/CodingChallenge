using CodingChallenge.Data.Classes;
using CodingChallenge.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data
{
    internal sealed class Cuadrado : FormasBuilder
    {
        private static Cuadrado _instancia = null;
        private decimal _lado;

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

        public override decimal CalcularArea()
        {
            var area = _lado * _lado;
            _areaAcum += area;
            return area;    
        }

        public override decimal CalcularPerimetro() 
        {
            var per = _lado * 4;
            _perimetroAcum += per;
            return per;
        }

        public override string TraducirForma(Idioma idioma)
        {
            switch (idioma)
            {
                case Idioma.Castellano: return _cantidad > 1 ? "Cuadrados" : "Cuadrado";
                case Idioma.Italiano: return _cantidad > 1 ? "Piazze" : "Piazza";
                default: return _cantidad > 1 ? "Squares" : "Square";
            }
        }
    }
}
