using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public MainController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet("tiempo")]
        [HttpGet("/tiempo")]
        //[HttpGet("tiempo/{nombre}/{apellido=Estevez}")]
        public ActionResult<string> GetDate(string nombre, string apellido)
        {
            return configuration["Key"];
        }
    }
}
