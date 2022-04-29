using SoilParamsAPI.Models;
using System.Collections.Generic;

namespace SoilParamsAPI.Interfaces
{
    public interface IParameterService
    {
        Result<Dictionary<string, double>> GetParameters(int id);
        Result<OutputModel>                CalculateParameters(InputQueryParameters input);
    }
}