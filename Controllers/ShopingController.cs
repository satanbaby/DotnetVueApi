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
  public class ShopingController : ControllerBase
  {
    private readonly ShopingContext SContext;
      public ShopingController(ShopingContext context) { 
        SContext = context;
        if(SContext.Members.Count()==0){
          SContext.Members.Add(new Member{UName="Item1",UId="1"});
          SContext.SaveChanges();
        }
      }

      // GET api/shoping
      [HttpGet]
      public ActionResult<List<Member>> GetAll()
      {
          return SContext.Members.ToList();
      }

      // GET api/shoping/5
      [HttpGet("{id}",Name="GetShoping")]
      public ActionResult<Member> GetById(string id)
      {
          var item = SContext.Members.Find(id);
          if(item==null){
            return Content("NotFound");
          }
          return item;
      }

      // POST api/shoping
      [HttpPost("")]
      public IActionResult Create(Member item){
        if (SContext.Members.Find(item.UId)==null){
        SContext.Members.Add(item);
        SContext.SaveChanges();
        return CreatedAtRoute("GetShoping",new {id=item.UId},item);
        }else{
          return NotFound();
        }
      }

      // PUT api/shoping/5
      [HttpPut("{id}")]
      //public void Put(int id, [FromBody] string value) { }
      public IActionResult Update(string id,Member item){
        var items = SContext.Members.Find(id);
        if (item==null){
            return NotFound();
        }
        items.UName=item.UName;
        items.UPwd=item.UPwd;

        SContext.Members.Update(items);
        SContext.SaveChanges();
        return Ok(items);
      }

      // DELETE api/shoping/5
      [HttpDelete("{id}")]
      public IActionResult Delete(string id){
        var member=SContext.Members.Find(id);
        if(member==null){
          return NotFound();
        }
        SContext.Members.Remove(member);
        SContext.SaveChanges();
        return NoContent();
      }
    }

    
}