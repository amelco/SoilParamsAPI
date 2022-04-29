using Microsoft.AspNetCore.Mvc;
using SoilParamsAPI.Interfaces;
using SoilParamsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoilParamsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametersController : ControllerBase
    {
        private IParameterService _service { get; set; }

        public ParametersController(IParameterService service)
        {
            _service = service;
        }

        /// <summary>
        /// Returns parameters of a previously analised soil sample
        /// </summary>
        /// <param name="id">Identification number of the soil sample</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Result<Dictionary<string,double>> Get(int id)
        {
            var res = _service.GetParameters(id);
            return res;
        }

        [HttpPost]
        public Result<OutputModel> Post([FromBody] InputQueryParameters input)
        {
            var res = _service.CalculateParameters(input);
            return res;

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
