using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using homework.Models;

namespace homework.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        public OrdersController() { }

        // GET api/orders
        [HttpGet("")]
        // public ActionResult<IEnumerable<string>> Gets()
        // {
        //     return new string[] { "value1", "value2" };
        // }
        public Order Get(){
          return new Order{
            OId="123",
            Member="1234",
            
          };
        }

        // GET api/orders/5
        [HttpGet("{id}")]
        public ActionResult<string> GetById(int id)
        {
            return "value" + id;
        }

        // POST api/orders
        [HttpPost("")]
        public void Post([FromBody] string value) { }

        // PUT api/orders/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) { }

        // DELETE api/orders/5
        [HttpDelete("{id}")]
        public void DeleteById(int id) { }
    }
}