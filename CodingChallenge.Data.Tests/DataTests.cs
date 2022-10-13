using CodingChallenge.Data.Domain;
using CodingChallenge.Data.Interfaces;
using CodingChallenge.Data.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            //Arrange
            IList<IGeometricForm> geometricForms = new List<IGeometricForm>();
            IReportingService reportingSvc = new ReportingService(new PrintSpanish());
            //Act
            string result = reportingSvc.Print(geometricForms);
            //Assert
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>", result);
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            //Arrange
            IList<IGeometricForm> geometricForms = new List<IGeometricForm>();
            IReportingService reportingSvc = new ReportingService(new PrintEnglish());
            //Act
            string result = reportingSvc.Print(geometricForms);
            //Assert
            Assert.AreEqual("<h1>Empty list of shapes!</h1>", result);
        }

        [TestCase]
        public void TestResumenListaVaciaEnPortugues()
        {
            //Arrange
            IList<IGeometricForm> geometricForms = new List<IGeometricForm>();
            IReportingService reportingSvc = new ReportingService(new PrintPortuguese());
            //Act
            string result = reportingSvc.Print(geometricForms);
            //Assert
            Assert.AreEqual("<h1>Lista vazia de formas!</h1>", result);
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            //Arrange
            IList<IGeometricForm> squares = new List<IGeometricForm> { new Square(5) };
            IReportingService reportingSvc = new ReportingService(new PrintSpanish());
            //Act
            string result = reportingSvc.Print(squares);
            //Assert
            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 Formas Perimetro 20 Area 25", result);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            //Arrange
            IList<IGeometricForm> squares = new List<IGeometricForm>
            {
                new Square(5),
                new Square(1),
                new Square(3)
            };
            IReportingService reportingSvc = new ReportingService(new PrintEnglish());
            //Act
            string result = reportingSvc.Print(squares);
            //Assert
            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 Shapes Perimeter 36 Area 35", result);
        }

        [TestCase]
        public void TestResumenListaConMasRectangulosEnPortugues()
        {
            //Arrange
            IList<IGeometricForm> rectangles = new List<IGeometricForm>
            {
                new Rectangle(5,8),
                new Rectangle(1,5), 
                new Rectangle(3,9) 
            };
            IReportingService reportingSvc = new ReportingService(new PrintPortuguese());
            //Act
            string result = reportingSvc.Print(rectangles);
            //Assert
            Assert.AreEqual("<h1>Relatório de Formas</h1>3 Retângulos | Area 72 | Perimetro 62 <br/>TOTAL:<br/>3 Formas Perimetro 62 Area 72", result);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            //Arrange
            IList<IGeometricForm> geometricForms = new List<IGeometricForm>
            {
                new Square(5),
                new Circle(3),
                new EquilateralTriangle(4),
                new Square(2),
                new EquilateralTriangle(9),
                new Circle(2.75m),
                new EquilateralTriangle(4.2m)
            };
            IReportingService reportingSvc = new ReportingService(new PrintEnglish());
            //Act
            string result = reportingSvc.Print(geometricForms);
            //Assert
            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 Shapes Perimeter 97,66 Area 91,65",
                result);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            //Arrange
            IList<IGeometricForm> geometricForms = new List<IGeometricForm>
            {
                new Square(5),
                new Circle(3),
                new EquilateralTriangle(4),
                new Square(2),
                new EquilateralTriangle(9),
                new Circle(2.75m),
                new EquilateralTriangle(4.2m)
            };
            IReportingService reportingSvc = new ReportingService(new PrintSpanish());
            //Act
            string result = reportingSvc.Print(geometricForms);
            //Assert
            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 Formas Perimetro 97,66 Area 91,65",
                result);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellanoIncluyendoNuevaForma()
        {
            //Arrange
            IList<IGeometricForm> geometricForms = new List<IGeometricForm>
            {
                new Square(5),
                new Circle(3),
                new EquilateralTriangle(4),
                new Square(2),
                new Rectangle(5,6),
                new EquilateralTriangle(9),
                new Circle(2.75m),
                new EquilateralTriangle(4.2m),
                new Rectangle(4,8)
            };
            IReportingService reportingSvc = new ReportingService(new PrintSpanish());
            //Act
            string result = reportingSvc.Print(geometricForms);
            //Assert
            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>" +
                "2 Cuadrados | Area 29 | Perimetro 28 <br/>" +
                "2 Círculos | Area 13,01 | Perimetro 18,06 <br/>" +
                "3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>" +
                "2 Rectangulos | Area 62 | Perimetro 46 <br/>" +
                "TOTAL:<br/>9 Formas Perimetro 143,66 Area 153,65",
                result);
        }
    }
}
