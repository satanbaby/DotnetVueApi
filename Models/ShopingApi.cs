using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace homework.Models
{
    public class Member{
      [Key]
      public string UId { get; set; }
      public string UPwd { get; set; }
      public string UName { get; set; }
      public DateTime RegisterTime { get; set; }
    }
    public class Login{
      public string uid { get; set; }
      public string pwd { get; set; }
    }

    public class Pruduct{
      [Key]
      public string PId { get; set; }
      public string PName { get; set; }
      public int Price { get; set; }
      public ushort Qty { get; set; }
      // public IList<Order> orders { get; set; }
    }
    public class Order{
      [Key]
      public string OId { get; set; }
      public int orderQty { get; set; }
      public DateTime CreateTime { get; set; }
      public Member Members { get; set; }
      public Pruduct PruductID{get;set;}
    }
    //輸入資料模型，不進入Dbset
    public class enterOrder{
        public string prdId { get; set; }
        public ushort qty { get; set; }
        public string memId { get; set; }
    }


    public class Admin{
      [Key]
      public string Account { get; set; }
      public string Password { get; set; }
      //public string[] Order { get; set; }
    } 
}