using CodingChallenge.Data.Domain.Forms;
using CodingChallenge.Data.Helpers;
using System.Collections.Generic;

namespace CodingChallenge.Data.Service
{
    public interface ICalculateReport
    {
        ResultForReport GetResults(List<GeometricForm> formsList);
    }
}
