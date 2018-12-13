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
            select new{ord.OId,mem.UName,ord.PruductID.PName,ord.PruductID.Price,ord.orderQty};
          result.data=item;
          result.success=true;
          result.meg="取得訂單資料成功";
            return result;
        }

        //POST api/orders
        [HttpPost("")]
        public ResultModel Create(Order item){
          var result = new ResultModel();
          return result;
        }

       
    }
}