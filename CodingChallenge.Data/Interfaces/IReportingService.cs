using System.Collections.Generic;

namespace CodingChallenge.Data.Interfaces
{
    public interface IReportingService
    {
        string Print(IList<IGeometricForm> geometricForms);
        string OtherMethod(IList<IGeometricForm> geometricForms);
    }
}
