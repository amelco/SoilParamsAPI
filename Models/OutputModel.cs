using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoilParamsAPI.Models
{
    public class OutputModel
    {
        public List<double> PressureHeads { get; set; }
        public List<double> MeasuredWaterContents { get; set; }
        public Dictionary<string, double> Params { get; set; }
        public List<double> InitialGuess { get; set; }
        public Statistics Stats { get; set; }

    }
    public class Statistics
    {
        public double MeasuredStandardDeviation { get; set; }
        public double MeasuredStandardError { get; set; }
        public double PredictedStandardDeviation { get; set; }
        public double PredictedStandardError { get; set; }
        public double PearsonCorrelation { get; set; }
        public double Rsquared { get; set; }
    }
}
