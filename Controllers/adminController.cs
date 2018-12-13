using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using homework.Models;

namespace homework.Controllers
{
  //////////////////管理員控制器//////////////////////
    [Route("[controller]")]
    [ApiController]
    public class adminController : Controller
    {
      private readonly ShopingContext SContext;
        public adminController(ShopingContext context) { 
          SContext=context;
        }
        //////////////////////////////////////////
        ////////////////getPruduct////////////////
        //////////////////////////////////////////

        // GET admin/pruduct
        [HttpGet("pruduct")]
        public ResultModel GetPrds()
        {
          var result = new ResultModel();
          result.data=SContext.Pruducts.ToList();
          result.success=true;
          result.meg="取得資料成功";
          return result;
        }
        //  GET admin/pruduct/{id}
        [HttpGet("pruduct/{id}")]
        public ResultModel GetPrdById(string id)
        {
          var result = new ResultModel();
          if(SContext.Pruducts.Find(id)==null){
            result.success=false;
            result.meg="此資料可能不存在";
            return result;
          }
          else{
            result.success=true;
            result.data=SContext.Pruducts.Where(m=>m.PId==id).FirstOrDefault();
            result.meg="取得資料成功";
            return result;
          }
        }
        // Post admin/pruduct
        [HttpPost("pruduct")]
        public ResultModel CreatePrd(Pruduct item){
          var result = new ResultModel();
          if(SContext.Pruducts.Find(item.PId)==null){
            SContext.Pruducts.Add(item);
            SContext.SaveChanges();
            result.success=true;
            result.meg="新增資料成功";
            result.data=item;
            return result;
          }else{
            result.success=false;
            result.meg="此ID可能已經存在";
            return result;
          }

        }
        //PUT admin/pruduct/{id}
        [HttpPut("pruduct/{id}")]
        public ResultModel Updape(string id,Pruduct item){
          var result = new  ResultModel();
          var items = SContext.Pruducts.Find(id);
          if(items==null){
            result.success=false;
            result.meg="此資料不存在";
            return result;
          }else{
              items.PId=item.PId.ToUpper()  ;
            items.PName=item.PName          ;
            items.Price=item.Price          ;
              items.Qty=item.Qty            ;
            SContext.Pruducts.Update(items) ;
            SContext.SaveChanges()          ;
              result.success=true            ;
              result.meg   ="修改資料成功"   ;
              result.data  =items           ;
            return result                   ;
          }
          
        }
        // DELETE pruduct/{id}
        [HttpDelete("pruduct/{id}")]
        public ResultModel DeletePrd(string id){
          var result = new ResultModel();
          var item=SContext.Pruducts.Find(id);
          if(item==null){
            result.meg="此ID不存在";
            result.success=false;
            return result;
          }
          SContext.Pruducts.Remove(item);
          SContext.SaveChanges();
          result.success=true;
          result.data=item;
          result.meg="刪除資料成功";
          return result;
        }

        /////////////////////////////////////////
        //////////////GetMember//////////////////
        /////////////////////////////////////////
        [HttpGet("member")]
        public ResultModel getMem(){
          var result = new ResultModel();
          result.meg="取得所有會員資訊";
          result.success=true;
          result.data=SContext.Members.ToList();
          return result;
        }

        [HttpGet("member/{id}")]
        public ResultModel getMemById(string id){
          var result = new ResultModel();
          var item = SContext.Members.Find(id);
          if(item==null){
            result.success=false;
            result.meg="取得會員資料失敗";
            return result;
          }
          result.data=item;
          result.success=true;
          result.meg="取得會員資料成功";
          return result;
        }
        ////////刪除會員
        [HttpDelete("member/{id}")]
        public ResultModel DelMem(string id){
          var result = new ResultModel();
          var item = SContext.Members.Find(id);
          if(item==null){
            result.success=false;
            result.meg="沒有這位會員喔";
            return result;
          }
          SContext.Members.Remove(item);
          SContext.SaveChanges();
          result.success=true;
          result.meg="刪除會員資料成功";
          return result;
        }




    }
}