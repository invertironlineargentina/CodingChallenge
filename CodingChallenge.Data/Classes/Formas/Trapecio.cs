using CodingChallenge.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Formas
{
    internal class Trapecio : FormasBuilder
    {
        private static Trapecio _instancia = null;
        private decimal _alto;
        private decimal _ancho;
        private decimal _anchoSuperior;

        private Trapecio()
        {
            TipoForma = TipoForma.TrianguloEquilatero;
        }

        public static Trapecio GetInstancia(decimal alto, decimal ancho, decimal anchoSuperior)
        {
            if (_instancia == null)
            {
                _instancia = new Trapecio();
            }

            _instancia._alto = alto;
            _instancia._ancho = ancho;
            _instancia._anchoSuperior = anchoSuperior;
            _instancia._cantidad++;

            return _instancia;
        }

        public override decimal CalcularArea()
        {
            decimal lado;
            if ( _ancho > _anchoSuperior)
                lado = _anchoSuperior + ((_ancho - _anchoSuperior) / 2);
            else
                lado = _ancho + ((_anchoSuperior - _ancho) / 2);

            var area = lado * _alto;
            _areaAcum += area;
            return area;
        }

        public override decimal CalcularPerimetro()
        {
            decimal lado;

            if (_anchoSuperior > _ancho) lado = (_anchoSuperior - _ancho) / 2;
            else lado = (_ancho - _anchoSuperior) / 2;

            var ladoDiagonal = Math.Sqrt(Math.Pow((double)lado, 2) + Math.Pow((double)_alto, 2));
            var per = _ancho + _anchoSuperior + ((decimal)ladoDiagonal * 2);
            _perimetroAcum += per;
            return per;
        }

        public override string TraducirForma(Idioma idioma)
        {
            switch (idioma)
            {
                case Idioma.Castellano: return _cantidad > 1 ? "Trapecios" : "Trapecio";
                case Idioma.Italiano: return _cantidad > 1 ? "Trapezi" : "Trapezio";
                default: return _cantidad > 1 ? "Trapezoids" : "Trapeze";
            }
        }
    }
}
