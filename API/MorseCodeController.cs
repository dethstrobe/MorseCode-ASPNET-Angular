using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using MorseCodeApp.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MorseCodeApp.API.Controllers
{
    [Route("api/[controller]")]
    public class MorseCodeController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Morse> Get()
        {
            return new List<Morse> {
                new Morse {id=1, name="Billy", gender="male"},
                new Morse {id=2, name="Joe", gender="male"},
                new Morse {id=3, name="Sue", gender="female"},
                new Morse {id=4, name="Lara", gender="female"}
            };
        }

        // // GET api/values/5
        // [HttpGet("{id}")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        // // POST api/values
        // [HttpPost]
        // public void Post([FromBody]string value)
        // {
        // }

        // // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody]string value)
        // {
        // }

        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
