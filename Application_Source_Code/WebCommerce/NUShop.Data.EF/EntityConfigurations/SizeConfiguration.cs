using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class SizeConfiguration : DbEntityConfiguration<Size>
    {
        public override void Configure(EntityTypeBuilder<Size> entity)
        {
            entity.ToTable("Sizes");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");
            entity.Property(x => x.Name).IsRequired(false).HasColumnName("Name").HasColumnType("nvarchar(255)");
            //entity.HasData(
            //    new Size() { Name = "XXL" },
            //    new Size() { Name = "XL" },
            //    new Size() { Name = "L" },
            //    new Size() { Name = "M" },
            //    new Size() { Name = "S" },
            //    new Size() { Name = "XS" });
        }
    }
}