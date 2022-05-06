using SoilParamsAPI.Interfaces;
using SoilParamsAPI.Models;
using SoilParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using SoilParamsAPI.Extensions;
using Microsoft.Extensions.Logging;

namespace SoilParamsAPI.Services
{
    public class ParameterService : IParameterService
    {
        private readonly ILogger<ParameterService> _logger;

        public ParameterService(ILogger<ParameterService> logger)
        {
            _logger = logger;
        }

        public Result<OutputModel> CalculateParameters(InputQueryParameters input)
        {
            OutputModel res;
            try
            {
                res = this.Calculate(JsonSerializer.Serialize(input));
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error: " + e.StackTrace);
                return new Result<OutputModel> { Success = false, Message = e.Message, Data = null };
            }
            return new Result<OutputModel> { Data = res };
        }

        public Result<Dictionary<string, double>> GetParameters(int id)
        {
            return new Result<Dictionary<string, double>> { Success = false, Data = null };
        }

        private OutputModel Calculate(string input)
        {
            var sample = new WRCParams(input);
            if (sample.WRCModel != null)
            {
                sample.CalculateParams();
                sample.CalculateWaterContents();
                sample.CalculateStatistics();
            }
            else
            {
                throw new Exception("Failed to read input string.");
            }

            return sample.ToOuputModel();
        }
    }
}
