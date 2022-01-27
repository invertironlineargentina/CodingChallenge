using System;
using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using CodingChallenge.Data.Domain.Forms;
using CodingChallenge.Data.Domain.Idioms;
using CodingChallenge.Data.Helpers;
using CodingChallenge.Data.Service;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        private Circle circle;
        private Square square;
        private Rectangle rectangle;
        private Trapeze trapeze;
        private EquilateralTriangle equilateralTriangle;
        private CalculateReport _service = new CalculateReport();

        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>", Report.Print(new List<GeometricForm>(), new Spanish(), _service));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>", Report.Print(new List<GeometricForm>(), new English(), _service));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var geometricsForms = new List<GeometricForm>();
            square = new Square(5);
            geometricsForms.Add(square);
            var resume = Report.Print(geometricsForms, new Spanish(), _service);
            Assert.AreEqual("<h1>Reporte de Formas!</h1><br>1 Cuadrado | Area 25 | Perimetro 20<br>TOTAL: 1 forma Perimetro 20 Area 25", resume);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var geometricsForms = new List<GeometricForm>();
            square = new Square(1);
            geometricsForms.Add(square);
            square = new Square(3);
            geometricsForms.Add(square);
            square = new Square(5);
            geometricsForms.Add(square);

            var resume = Report.Print(geometricsForms, new English(), _service);
            Assert.AreEqual("<h1>Shapes report!</h1><br>3 Squares | Area 35 | Perimeter 36<br>TOTAL: 3 shapes Perimeter 36 Area 35", resume);
        }
        
        [TestCase]
        public void TestResumenListaConMasTiposEnIngles()
        {
            var geometricsForms = new List<GeometricForm>();

            square = new Square(5);
            geometricsForms.Add(square);

            circle = new Circle(3);
            geometricsForms.Add(circle);

            equilateralTriangle = new EquilateralTriangle(4);
            geometricsForms.Add(equilateralTriangle);

            square = new Square(2);
            geometricsForms.Add(square);

            equilateralTriangle = new EquilateralTriangle(9);
            geometricsForms.Add(equilateralTriangle);

            circle = new Circle(2.75m);
            geometricsForms.Add(circle);

            equilateralTriangle = new EquilateralTriangle(4.2m);
            geometricsForms.Add(equilateralTriangle);

            var resume = Report.Print(geometricsForms, new English(), _service);
            Assert.AreEqual(
                "<h1>Shapes report!</h1><br>2 Squares | Area 29 | Perimeter 28<br>3 Equilateral Triangles | Area 49,64 | Perimeter 51,6<br>2 Circles | Area 13,01 | Perimeter 18,06<br>TOTAL: 7 shapes Perimeter 97,66 Area 91,65",
                resume);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnEspañol()
        {
            var geometricsForms = new List<GeometricForm>();

            square = new Square(5);
            geometricsForms.Add(square);

            circle = new Circle(3);
            geometricsForms.Add(circle);

            equilateralTriangle = new EquilateralTriangle(4);
            geometricsForms.Add(equilateralTriangle);

            square = new Square(2);
            geometricsForms.Add(square);

            equilateralTriangle = new EquilateralTriangle(9);
            geometricsForms.Add(equilateralTriangle);

            circle = new Circle(2.75m);
            geometricsForms.Add(circle);

            equilateralTriangle = new EquilateralTriangle(4.2m);
            geometricsForms.Add(equilateralTriangle);

            var resume = Report.Print(geometricsForms, new Spanish(), _service);
            Assert.AreEqual("<h1>Reporte de Formas!</h1><br>2 Cuadrados | Area 29 | Perimetro 28<br>3 Triángulos Equilateros | Area 49,64 | Perimetro 51,6<br>2 Círculos | Area 13,01 | Perimetro 18,06<br>TOTAL: 7 formas Perimetro 97,66 Area 91,65", resume);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnFrances()
        {
            var geometricsForms = new List<GeometricForm>();

            square = new Square(5);
            geometricsForms.Add(square);

            circle = new Circle(3);
            geometricsForms.Add(circle);

            equilateralTriangle = new EquilateralTriangle(4);
            geometricsForms.Add(equilateralTriangle);

            square = new Square(2);
            geometricsForms.Add(square);

            equilateralTriangle = new EquilateralTriangle(9);
            geometricsForms.Add(equilateralTriangle);

            var resume = Report.Print(geometricsForms, new French(), _service);
            Assert.AreEqual("<h1>Rapport de formes!</h1><br>2 Des Carrés | Zone 29 | Périmètre 28<br>2 Triangles équilatéraux | Zone 42 | Périmètre 39<br>1 Cercle | Zone 7,07 | Périmètre 9,42<br>TOTAL: 5 des formes Périmètre 76,42 Zone 78,07", resume);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecioEnIngles()
        {
            var geometricsForms = new List<GeometricForm>();

            trapeze = new Trapeze(7, 3, 5, 4.12m);
            geometricsForms.Add(trapeze);

            var resume = Report.Print(geometricsForms, new English(), _service);
            Assert.AreEqual("<h1>Shapes report!</h1><br>1 Trapeze | Area 19,99 | Perimeter 19,12<br>TOTAL: 1 shape Perimeter 19,12 Area 19,99", resume);
        }

        [TestCase]
        public void TestResumenListaConTrapecioYRectanguloEnFrances()
        {
            var geometricsForms = new List<GeometricForm>();

            trapeze = new Trapeze(7, 3, 5, 4.12m);
            geometricsForms.Add(trapeze);

            rectangle = new Rectangle(2, 3);
            geometricsForms.Add(rectangle);

            trapeze = new Trapeze(7, 3, 5, 4.12m);
            geometricsForms.Add(trapeze);

            rectangle = new Rectangle(2, 4);
            geometricsForms.Add(rectangle);

            var resumen = Report.Print(geometricsForms, new French(), _service);
            Assert.AreEqual("<h1>Rapport de formes!</h1><br>2 Trapèzes | Zone 39,98 | Périmètre 38,24<br>2 Des Rectangles | Zone 14 | Périmètre 22<br>TOTAL: 4 des formes Périmètre 60,24 Zone 53,98", resumen);
        }
    }
}
