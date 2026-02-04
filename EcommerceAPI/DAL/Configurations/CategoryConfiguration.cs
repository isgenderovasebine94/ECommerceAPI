using EcommerceAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace EcommerceAPI.DAL.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //builder.Property<int>("Id");
            //builder.Property(c => c.Name).IsRequired().HasMaxLength(40).HasColumnType(SqlDbType.VarChar.ToString());

            //builder.HasMany(b => b.Products)
            //    .WithOne(p => p.Category)
            //    .HasForeignKey(p => p.CategoryId);

            builder.HasData(
            new Category { Id = 1, Name = "Elektronika" },
            new Category { Id = 2, Name = "Geyim" },
            new Category { Id = 3, Name = "Kitab" });
        }
    }
}
