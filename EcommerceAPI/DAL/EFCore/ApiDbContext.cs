using System.Reflection;
using EcommerceAPI.Entities;
using EcommerceAPI.Entities.Auth;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace EcommerceAPI.DAL.EFCore
{
    public class ApiDbContext : IdentityDbContext<AppUser>
    {
        public ApiDbContext(DbContextOptions<ApiDbContext>options): base(options)
        {

        }
        
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        //public DbSet<Brand> Brands { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }
    }
}
