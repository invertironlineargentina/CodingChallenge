using System.Collections.Generic;

namespace CodingChallenge.Data.Interfaces
{
    public interface IPrint
    {
        string CreatePrint(IList<IGeometricForm> geometricForms);
    }
}
