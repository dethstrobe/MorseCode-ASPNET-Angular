using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using WebApp.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.API.Controllers
{
    [Route("api/[controller]")]
    public class MorseCodeController : Controller
    {
        // private readonly MorseCodeContext _dbContext;

        public int MorseId = 5;

        public static List<Morse> initialList = new List<Morse> {
                new Morse {id=1, name="Billy", gender="male"},
                new Morse {id=2, name="Joe", gender="male"},
                new Morse {id=3, name="Sue", gender="female"},
                new Morse {id=4, name="Lara", gender="female"}
            };

        // public MorseCodeController(MorseCodeContext dbContext) 
        // {
        //     List<Morse> initialList = new List<Morse> {
        //         new Morse {id=1, name="Billy", gender="male"},
        //         new Morse {id=2, name="Joe", gender="male"},
        //         new Morse {id=3, name="Sue", gender="female"},
        //         new Morse {id=4, name="Lara", gender="female"}
        //     };
        // }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Morse> Get()
        {
            return initialList;
        }

        [HttpPost]
        public List<Morse> Post([FromBody]Morse morse)
        {
            List<Morse> listToAdd = new List<Morse>{
                new Morse {id=MorseId++, name=morse.name, gender=morse.gender}
            };
            // Put whatever you want in the second list
            initialList.AddRange(listToAdd);

            return initialList;
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
