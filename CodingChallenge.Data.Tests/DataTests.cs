using System;
using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using CodingChallenge.Data.Enums;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), Idioma.Castellano));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), Idioma.Ingles));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            Assert.AreEqual("<h1>Elenco vuoto di forme!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), Idioma.Italiano));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> {new FormaGeometrica(TipoForma.Cuadrado, 5)};

            var resumen = FormaGeometrica.Imprimir(cuadrados, Idioma.Castellano);
            Console.WriteLine(resumen);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 forma Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecio()
        {
            var trapecios = new List<FormaGeometrica> { new FormaGeometrica(TipoForma.Trapecio, 5, 12, 8) };

            var resumen = FormaGeometrica.Imprimir(trapecios, Idioma.Castellano);
            Console.WriteLine(resumen);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Trapecio | Area 50 | Perimetro 30,77 <br/>TOTAL:<br/>1 forma Perimetro 30,77 Area 50", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new FormaGeometrica(TipoForma.Cuadrado, 5),
                new FormaGeometrica(TipoForma.Cuadrado, 1),
                new FormaGeometrica(TipoForma.Cuadrado, 3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, Idioma.Ingles);
            Console.WriteLine(resumen);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaDeRectangulos()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(TipoForma.Rectangulo, 3, 4),
                new FormaGeometrica(TipoForma.Rectangulo, 2, 5)
            };

            var resumen = FormaGeometrica.Imprimir(formas, Idioma.Castellano);
            Console.WriteLine(resumen);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Rectángulos | Area 22 | Perimetro 28 <br/>TOTAL:<br/>2 formas Perimetro 28 Area 22",
                resumen
            );
        }

        [TestCase]
        public void TestResumenListaDeTrapeciosItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(TipoForma.Trapecio, 3, 4, 5),
                new FormaGeometrica(TipoForma.Trapecio, 4, 5, 2),
                new FormaGeometrica(TipoForma.Trapecio, 3, 2, 6)
            };

            var resumen = FormaGeometrica.Imprimir(formas, Idioma.Italiano);
            Console.WriteLine(resumen);

            Assert.AreEqual(
                "<h1>Rapporto sui moduli</h1>3 Trapezi | Area 39,5 | Perimetro 45,84 <br/>TOTAL:<br/>3 forme Perimetro 45,84 Area 39,5",
                resumen
            );
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(TipoForma.Cuadrado, 5),
                new FormaGeometrica(TipoForma.Circulo, 3),
                new FormaGeometrica(TipoForma.TrianguloEquilatero, 4),
                new FormaGeometrica(TipoForma.Cuadrado, 2),
                new FormaGeometrica(TipoForma.TrianguloEquilatero, 9),
                new FormaGeometrica(TipoForma.Circulo, 2.75m),
                new FormaGeometrica(TipoForma.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, Idioma.Ingles);
            Console.WriteLine(resumen);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(TipoForma.Cuadrado, 5),
                new FormaGeometrica(TipoForma.Circulo, 3),
                new FormaGeometrica(TipoForma.TrianguloEquilatero, 4),
                new FormaGeometrica(TipoForma.Cuadrado, 2),
                new FormaGeometrica(TipoForma.TrianguloEquilatero, 9),
                new FormaGeometrica(TipoForma.Circulo, 2.75m),
                new FormaGeometrica(TipoForma.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, Idioma.Castellano);
            Console.WriteLine(resumen);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaCoTodosLosTiposEnItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(TipoForma.Cuadrado, 5),
                new FormaGeometrica(TipoForma.Circulo, 3),
                new FormaGeometrica(TipoForma.TrianguloEquilatero, 4),
                new FormaGeometrica(TipoForma.Cuadrado, 2),
                new FormaGeometrica(TipoForma.Rectangulo, 9, 4),
                new FormaGeometrica(TipoForma.Circulo, 2.75m),
                new FormaGeometrica(TipoForma.TrianguloEquilatero, 4.2m),
                new FormaGeometrica(TipoForma.Trapecio, 3, 2.4m, 2)
            };

            var resumen = FormaGeometrica.Imprimir(formas, Idioma.Italiano);
            Console.WriteLine(resumen);

            Assert.AreEqual(
                "<h1>Rapporto sui moduli</h1>2 Piazze | Area 29 | Perimetro 28 <br/>2 Cerchi | Area 13,01 | Perimetro 18,06 <br/>2 Triangolo | Area 14,57 | Perimetro 24,6 <br/>" + 
                "1 Rettangolo | Area 36 | Perimetro 26 <br/>1 Trapezio | Area 6,6 | Perimetro 10,41 <br/>" + 
                "TOTAL:<br/>8 forme Perimetro 107,08 Area 99,17",
                resumen);
        }
    }
}
