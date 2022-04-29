namespace SoilParamsAPI.Models
{
    public class Result<T>
    {
        public bool     Success { get; set; } = true;
        public string   Message { get; set; } = "";
        public T        Data   { get; set;  }
    }
}