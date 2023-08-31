using CodingChallenge.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Formas
{
    internal class Trapecio : IBuilder
    {
        private static Trapecio _instancia = null;
        private decimal _lado;
        private decimal _ancho;
        private decimal _anchoSuperior;

        private int _cantidad = 0;
        private decimal _perimetroAcum = 0m;
        private decimal _areaAcum = 0m;

        public TipoForma TipoForma { get; set; }

        private Trapecio()
        {
            TipoForma = TipoForma.TrianguloEquilatero;
        }

        public static Trapecio GetInstancia(decimal lado, decimal ancho, decimal anchoSuperior)
        {
            if (_instancia == null)
            {
                _instancia = new Trapecio();
            }

            _instancia._lado = lado;
            _instancia._ancho = ancho;
            _instancia._anchoSuperior = anchoSuperior;
            _instancia._cantidad++;

            return _instancia;
        }

        public decimal CalcularArea()
        {
            var area = ((_ancho + _anchoSuperior) / 2) * _lado;
            _areaAcum += area;
            return area;
        }

        public decimal CalcularPerimetro()
        {
            var anchoMenor = _ancho > _anchoSuperior ? _anchoSuperior : _ancho;
            decimal cateto;

            if (anchoMenor == _ancho) cateto = (_anchoSuperior - _ancho) / 2;
            else cateto = (_anchoSuperior - _ancho) / 2;

            var ladoDiagonal = Math.Sqrt(Math.Pow((double)cateto, 2) + Math.Pow((double)_lado, 2));

            var per = _ancho + _anchoSuperior + ((decimal)ladoDiagonal * 2);
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
                case Idioma.Castellano: return _cantidad > 1 ? "Trapecios" : "Trapecios";
                case Idioma.Italiano: return _cantidad > 1 ? "Trapezi" : "Trapezio";
                default: return _cantidad > 1 ? "Trapezoids" : "Trapeze";
            }
        }
    }
}
