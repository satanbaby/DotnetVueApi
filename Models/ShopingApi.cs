using System.ComponentModel.DataAnnotations;

namespace homework.Models
{
    public class Member{
      [Key]
      public string UId { get; set; }
      public string UPwd { get; set; }
      public string UName { get; set; }
      
    }

    public class Pruduct{
      [Key]
      public string PId { get; set; }
      public string PName { get; set; }
      public int Price { get; set; }
      public int Qty { get; set; }
    }
    public class Order{
      [Key]
      public string OId { get; set; }
      public string Member { get; set; }
      //public string[] Pruduct { get; set; }
    }
    public class Admin{
      [Key]
      public string Account { get; set; }
      public string Password { get; set; }
      //public string[] Order { get; set; }
    } 
}