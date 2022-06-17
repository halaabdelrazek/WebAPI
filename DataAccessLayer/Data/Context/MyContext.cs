using DataAccessLayer.Data.DataBaseModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Context
{
    public class MyContext : IdentityDbContext<User>
    {
       
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("User");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<ProductOrder>()
                .HasKey(p => new { p.ProductId, p.OrderId });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<ProductOrder> ProductOrders { get; set; }


    }
}
