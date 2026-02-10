using EcommerceAPI.Entities;
using EcommerceAPI.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EcommerceAPI.DAL
{
    public class EcommerceDbContext :IdentityDbContext<AppUser>

    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder
            //    .Entity<Product>()
            //    .Property(p => p.Name)
            //    .HasDefaultValueSql("XXX")
            //    .HasMaxLength(100)
            //    .IsRequired();
            //modelBuilder
            //    .Entity<Product>()
            //    .Property(p => p.Price)
            //    .HasDefaultValueSql("XXX")
            //    .HasMaxLength(100)
            //    .IsRequired();

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<IdentityPasskeyData>();
                    }


};

        }


       
    
