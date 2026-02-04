using EcommerceAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EcommerceAPI.DAL
{
    public class EcommerceDbContext : DbContext

    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

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
                    }


};

        }


       
    
