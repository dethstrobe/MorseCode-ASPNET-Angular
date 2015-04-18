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
        //A list of items to be held in memory
        public static List<Morse> initialList = new List<Morse> {
                new Morse {id=1, name="Billy", gender="male"},
                new Morse {id=2, name="Joe", gender="male"},
                new Morse {id=3, name="Sue", gender="female"},
                new Morse {id=4, name="Lara", gender="female"}
            };

        // GET: api/morsecode
        [HttpGet]
        public IEnumerable<Morse> Get()
        {
            return initialList;
        }

        // POST: api/morsecode
        [HttpPost]
        public List<Morse> Post([FromBody]Morse morse)
        {
            //finds the last ID used and increases it by 1
            int NextId = initialList[initialList.Count - 1].id+1;

            //makes a new list based off the information posted
            List<Morse> listToAdd = new List<Morse>{
                new Morse {id=NextId, name=morse.name, gender=morse.gender}
            };

            // Adds the second list back in to the first list
            initialList.AddRange(listToAdd);

            return initialList;
        }

        // Delete: api/morsecode/[id]
        [HttpDelete("{id:int}")]
        public List<Morse> Delete(int Id)
        {
            
            initialList.RemoveAll(Morse => Morse.id == Id);

            return initialList;
        }
    }
}
