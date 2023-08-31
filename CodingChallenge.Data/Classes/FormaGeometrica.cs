using CodingChallenge.Data.Classes.Formas;
using CodingChallenge.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        private readonly decimal _ancho;
        private readonly decimal _alto;
        private readonly decimal _anchoSuperior;

        public TipoForma TipoForma { get; set; }


        public FormaGeometrica(TipoForma tipo, decimal alto, decimal ancho = 0m,  decimal anchoSuperior = 0m)
        {
            TipoForma = tipo;
            _alto = alto;
            _ancho = ancho;
            _anchoSuperior = anchoSuperior;
        }

        private static string CrearHeader(Idioma idioma, int totalItems = 0)
        {
            string contenido;

            switch (idioma)
            {
                case Idioma.Castellano:
                    contenido = totalItems == 0 ? "Lista vacía de formas!" : "Reporte de Formas";
                    break;
                case Idioma.Ingles:
                    contenido = totalItems == 0 ? "Empty list of shapes!" : "Shapes report";
                    break;
                case Idioma.Italiano:
                    contenido = totalItems == 0 ? "Elenco vuoto di forme!" : "Rapporto sui moduli";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return $"<h1>{contenido}</h1>";
        }

        public static string Imprimir(List<FormaGeometrica> formas, Idioma idioma)
        {
            var header = CrearHeader(idioma, formas.Count());
            if (!formas.Any()) return header;

            var sb = new StringBuilder();
            sb.Append(header);

            var sumatoriaAreas = 0m;
            var sumatoriaPerimetros = 0m;
            var formasAcum = new List<IFormasBuilder>();

            formas.ForEach(f =>
            {
                FormasBuilder forma = GetFormaGeometrica(f.TipoForma, f._alto, f._ancho, f._anchoSuperior);

                if (formasAcum.FirstOrDefault(fa => fa.TipoForma == f.TipoForma) == null) formasAcum.Add(forma);
                sumatoriaAreas += forma.CalcularArea();
                sumatoriaPerimetros += forma.CalcularPerimetro();
            });

            formasAcum.ForEach(tf => {
                sb.Append(tf.ObtenerLinea(idioma));
                tf.Reset();
            });

            // FOOTER
            sb.Append("TOTAL:<br/>");
            sb.Append(formas.Count() + " " + TraducirForma(idioma, formas.Count()) + " ");
            sb.Append((idioma == Idioma.Ingles ? "Perimeter " : "Perimetro ") + sumatoriaPerimetros.ToString("#.##") + " ");
            sb.Append("Area " + sumatoriaAreas.ToString("#.##"));

            return sb.ToString();
        }

        public static FormasBuilder GetFormaGeometrica (TipoForma tipo, decimal alto, decimal ancho, decimal anchoSuperior )
        {
            switch(tipo)
            {
                case TipoForma.Cuadrado: 
                    return Cuadrado.GetInstancia(alto);
                case TipoForma.Circulo:
                    return Circulo.GetInstancia(alto);
                case TipoForma.TrianguloEquilatero:
                    return Triangulo.GetInstancia(alto);
                case TipoForma.Rectangulo:
                    return Rectangulo.GetInstancia(alto, ancho);
                case TipoForma.Trapecio:
                    return Trapecio.GetInstancia(alto, ancho, anchoSuperior);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string TraducirForma(Idioma idioma, int cantidad)
        {
            switch (idioma)
            {
                case Idioma.Castellano: return cantidad > 1 ? "formas" : "forma";
                case Idioma.Italiano: return cantidad > 1 ? "forme" : "forma";
                default: return cantidad > 1 ? "shapes" : "shape";
            }
        }
    }
}
