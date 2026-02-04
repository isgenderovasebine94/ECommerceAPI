using EcommerceAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceAPI.DAL.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //builder.Property<int>("Id");
            //builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
            //builder.Property(p => p.Desc).IsRequired().HasMaxLength(100);
            //builder.Property(p => p.Name).HasMaxLength(40).HasDefaultValue("Masin");


            builder.HasData(
            new Product
            {
                Id = 1,
                Name = "iPhone 15",
                Desc = "Apple telefon",
                Price = 2999.99m,
                CategoryId = 1
            },
            new Product
            {
                Id = 2,
                Name = "Clean Code",
                Desc = "Proqramlaşdırma kitabı",
                Price = 35.00m,
                CategoryId = 3
            }
        );
        }

       
    }
}
