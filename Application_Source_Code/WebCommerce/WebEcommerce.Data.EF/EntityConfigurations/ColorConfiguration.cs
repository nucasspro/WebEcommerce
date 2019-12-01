using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebEcommerce.Data.EF.Extensions;
using WebEcommerce.Data.Entities;

namespace WebEcommerce.Data.EF.EntityConfigurations
{
    public class ColorConfiguration: DbEntityConfiguration<Color>
    {
        public override void Configure(EntityTypeBuilder<Color> entity)
        {
            entity.ToTable("Colors");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");
            entity.Property(x => x.Name).IsRequired(false).HasColumnName("Name").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Code).IsRequired(false).HasColumnName("Code").HasColumnType("nvarchar(255)");
        }
    }
}