using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using homework.Models;

namespace homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruductController : ControllerBase
    {
        private readonly ShopingContext SContext;
        public PruductController(ShopingContext context) { 
          SContext = context;
        }
        // GET api/pruduct
        [HttpGet("")]
        public ActionResult<List<Pruduct>> GetAll()
        {
          return SContext.Pruducts.ToList();
        }

        // GET api/pruduct/5
        [HttpGet("{id}")]
        public ActionResult<string> GetById(int id)
        {
            return "value" + id;
        }

        // POST api/pruduct
        [HttpPost("")]
        public void Post([FromBody] string value) { }

        // PUT api/pruduct/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) { }

        // DELETE api/pruduct/5
        [HttpDelete("{id}")]
        public void DeleteById(int id) { }
    }
}