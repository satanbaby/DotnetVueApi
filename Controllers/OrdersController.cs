using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using homework.Models;
using Microsoft.EntityFrameworkCore;

namespace homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        // public OrdersController() { }
        private readonly ShopingContext SContext;
        public OrdersController(ShopingContext context) { 
          SContext=context;
        }

        // GET api/orders
        [HttpGet("")]
        public ResultModel Gets()
        {
          var result = new ResultModel();
            var order = SContext.Orders;
            var pruduct = SContext.Pruducts;
            var member = SContext.Members;
            var item = 
              from ord in order
              join prd in pruduct on ord.PruductID.PId equals prd.PId
              join mem in member on ord.Members.UId equals mem.UId
            select new{ ord.OId,mem.UName,
                        ord.PruductID.PName,
                        ord.PruductID.Price,
                        ord.orderQty,
                        ord.CreateTime};
          result.data=item;
          result.success=true;
          result.meg="取得訂單資料成功";
            return result;
        }

        [HttpGet("Test")]
        public ResultModel GetModel(){
          ResultModel result = new ResultModel();
          var ord = SContext.Orders;
          var prd = SContext.Pruducts;

          var q = ord.Select(item => new{
                    item.OId,
                    item.orderQty
                  })
                  ;
          
          result.data = q;
          return result;
        }


        // [HttpGet("testSP")]
        // public ResultModel get(){
        //   var result = new ResultModel();
        //   var item = SContext.Pruducts
        //               .FromSql("SELECT * FROM Pruducts")
        //               .ToList();
        //   result.data=item;
        //   result.success=true;
        //   return result;
        // }

        //POST api/orders
        [HttpPost("")]
        public ResultModel Create(enterOrder item){
          var result = new ResultModel();
          if(item.qty<1){
            result.success=false;
            result.meg="訂單數量不得為負";
          }else if(item.qty<SContext.Pruducts.Find(item.prdId).Qty){
          //如果訂單數量大於產品存貨
            var newOrd = new Order{
              OId=DateTime.Now.ToString("yyyyMMddHHmmss"),
              PruductID=SContext.Pruducts.Find(item.prdId),
              orderQty=item.qty,
              Members=SContext.Members.Find(item.memId),
              CreateTime=DateTime.Now,
            };
            SContext.Orders.Add(newOrd);
            SContext.Pruducts.Find(item.prdId).Qty-=item.qty;
            SContext.SaveChanges();
            
            result.meg="加入訂單成功";
            result.success=true;
            result.data=newOrd;
          }else{
            result.meg="數量不夠";
            result.success=false;
          }

            return result;
        }

        

       
    }
}