namespace CodingChallenge.Data.Domain
{
    public class GeometricForm
    {
        private readonly decimal _lado;

        public int Tipo { get; set; }

        public GeometricForm(int tipo, decimal ancho)
        {
            Tipo = tipo;
            _lado = ancho;
        }
    }
}
