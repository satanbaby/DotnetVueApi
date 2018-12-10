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
        // public OrdersController() { }
        private readonly ShopingContext SContext;
        public OrdersController(ShopingContext context) { 
          SContext=context;
        }

        // GET api/orders
        [HttpGet("")]
        public IActionResult Gets()
        {
            var order = SContext.Orders;
            var pruduct = SContext.Pruducts;
            var member = SContext.Members;
            var item = 
            from ord in order
            join prd in pruduct on ord.PruductID.PId equals prd.PId
            join mem in member on ord.Members.UId equals mem.UId
            select new{ord.OId,mem.UName,ord.PruductID.PName,ord.orderQty};
            
            return Json(item);
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