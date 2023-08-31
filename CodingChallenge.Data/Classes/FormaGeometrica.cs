/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

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
        protected readonly decimal _lado;
        protected readonly decimal _alto;
        protected readonly decimal _anchoSuperior;

        public TipoForma TipoForma { get; set; }


        public FormaGeometrica(TipoForma tipo, decimal ancho, decimal alto = 0m, decimal anchoSuperior = 0m)
        {
            TipoForma = tipo;
            _lado = ancho;
            _alto = alto;
            _anchoSuperior = anchoSuperior;
        }

        private static string CrearHeader(Idioma idioma, int totalItems = 0)
        {
            string contenido;

            if (totalItems == 0)
                contenido = idioma == Idioma.Castellano ? "Lista vacía de formas!" : "Empty list of shapes!";
            else
                contenido = idioma == Idioma.Castellano ? "Reporte de Formas" : "Shapes report";

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
            var formasAcum = new List<IBuilder>();

            formas.ForEach(f =>
            {
                IBuilder forma;
                if (f.TipoForma == TipoForma.Cuadrado) forma = Cuadrado.GetInstancia(f._lado);
                else if (f.TipoForma == TipoForma.Circulo) forma = Circulo.GetInstancia(f._lado);
                else if (f.TipoForma == TipoForma.TrianguloEquilatero) forma = Triangulo.GetInstancia(f._lado);
                else forma = Cuadrado.GetInstancia(f._lado);
                

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
            sb.Append((idioma == Idioma.Castellano ? "Perimetro " : "Perimeter ") + sumatoriaPerimetros.ToString("#.##") + " ");
            sb.Append("Area " + sumatoriaAreas.ToString("#.##"));

            return sb.ToString();
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
