using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = new ObjectResult(new { message = "Dogs house service. Version 1.0.1" });
                return result;
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please try again later");
            }
        }

    }
}
