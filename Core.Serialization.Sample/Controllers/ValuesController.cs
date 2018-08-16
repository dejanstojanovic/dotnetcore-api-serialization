using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Serialization.Sample.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core.Serialization.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok(new Person()
            {
                Id = id,
                Email = "test@mail.com",
                Name = "John Smith"
            });
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Person value)
        {
        }
    }
}
