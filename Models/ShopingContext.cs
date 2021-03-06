using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace homework.Models {
    public class ShopingContext : DbContext {
        public ShopingContext (DbContextOptions<ShopingContext> options) : base (options) { }
        public DbSet<Member> Members { get; set; }
        public DbSet<Pruduct> Pruducts{get;set;}
        public DbSet<Order> Orders{get;set;}
        public DbSet<Admin> Admins{get;set;}
    }
}