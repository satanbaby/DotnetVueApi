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
  public class ShopingController : ControllerBase
  {
    private readonly ShopingContext SContext;
    
      public ShopingController(ShopingContext context) { 
        SContext = context;
      }
      //=================登入===============
      [HttpPost("login")]
      public ActionResult Login(Member item){
        var members=SContext.Members;
        var member = members.Where(m=>m.UId==item.UId&& m.UPwd==item.UPwd).FirstOrDefault();
        if(member==null){
          HttpContext.Session.Clear();
          return NotFound();
        }
        Response.Cookies.Append("name",item.UName);
        return Ok(member);
      }
      //=================登出===============
      [HttpGet("logout")]
      public ActionResult Logout(){
        HttpContext.Session.Clear();
        return Ok();
      }
      // POST api/shoping
      [HttpPost("")]
      public ResultModel Create(Member item){
        var result = new ResultModel();
        if (SContext.Members.Find(item.UId)==null){
          item.RegisterTime=DateTime.Now;
          SContext.Members.Add(item);
          SContext.SaveChanges();
          result.success=true;
          result.meg="註冊成功";
          result.data=SContext.Members.Find(item.UId);

        return result;
        }else{
          result.success=false;
          result.meg="註冊失敗，可能已有該帳號";
          return result;
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