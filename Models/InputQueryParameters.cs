using System.Collections.Generic;

namespace SoilParamsAPI.Models
{
    public class InputQueryParameters
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<double> PressureHeads { get; set; }
        public List<double> MeasuredWaterContents { get; set; }
        public string Model { get; set; }
        public List<double> InitialGuess { get; set; }
    }
}