using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class ColorConfiguration : DbEntityConfiguration<Color>
    {
        public override void Configure(EntityTypeBuilder<Color> entity)
        {
            entity.ToTable("Colors");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");
            entity.Property(x => x.Name).IsRequired(false).HasColumnName("Name").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Code).IsRequired(false).HasColumnName("Code").HasColumnType("nvarchar(255)");
            //entity.HasData(
            //    new Color() { Name = "Black", Code = "#000000" },
            //    new Color() { Name = "White", Code = "#FFFFFF" },
            //    new Color() { Name = "Red", Code = "#ff0000" },
            //    new Color() { Name = "Blue", Code = "#1000ff" });
        }
    }
}