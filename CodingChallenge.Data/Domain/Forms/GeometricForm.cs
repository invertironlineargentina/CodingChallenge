
namespace CodingChallenge.Data.Domain.Forms
{
    public abstract class GeometricForm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeForm Type { get; set; }


        public abstract decimal CalculateArea();
        public abstract decimal CalculatePerimeter();
    }
}
