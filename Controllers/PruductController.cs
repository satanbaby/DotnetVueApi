using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using homework.Models;
using Microsoft.AspNetCore.Http;

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
        public ActionResult<Pruduct> GetById(string id)
        {
            var items = SContext.Pruducts.Find(id);
            if (items==null){
              return NotFound();
            }
            return items;
        }

        // POST api/pruduct
        [HttpPost("")]
        public IActionResult Create(Pruduct item){
          if(SContext.Pruducts.Find(item.PId)==null){
            item.PId=item.PId.ToUpper();
            SContext.Pruducts.Add(item);
            SContext.SaveChanges();
            return CreatedAtRoute("GetShoping",new {id=item.PId},item);
          }
            return NotFound();
        }

        // PUT api/pruduct/5
        [HttpPut("{id}")]
        public IActionResult Update(string id,Pruduct item){
        var items = SContext.Pruducts.Find(id);
        if (items==null){
            return NotFound();
        }
        items.PId=item.PId.ToUpper();
        items.PName=item.PName;
        items.Price=item.Price;
        items.Qty=item.Qty;

        SContext.Pruducts.Update(items);
        SContext.SaveChanges();
        return Ok(items);
      }

        // DELETE api/pruduct/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id){
          var item=SContext.Pruducts.Find(id);
          if(item==null){
            return NotFound();
          }
          SContext.Pruducts.Remove(item);
          SContext.SaveChanges();
          return NoContent();
        }
    }
}