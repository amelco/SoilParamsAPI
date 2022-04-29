using SoilParams;
using SoilParamsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoilParamsAPI.Extensions
{
    public static class WRCParamsExtension
    {
        public static OutputModel ToOuputModel(this WRCParams w)
        {
            return new OutputModel()
            {
                PressureHeads = w.PressureHeads,
                MeasuredWaterContents = w.MeasuredWaterContents,
                InitialGuess = w.InitialGuess,
                Params = w.Params,
                Stats = new()
                {
                    MeasuredStandardDeviation = w.Stats.MeasuredStandardDeviation,
                    MeasuredStandardError = w.Stats.MeasuredStandardError,
                    PredictedStandardDeviation = w.Stats.PredictedStandardDeviation,
                    PredictedStandardError = w.Stats.PredictedStandardError,
                    PearsonCorrelation = w.Stats.PearsonCorrelation,
                    Rsquared = w.Stats.Rsquared
                }
            };
        }
    }
}
