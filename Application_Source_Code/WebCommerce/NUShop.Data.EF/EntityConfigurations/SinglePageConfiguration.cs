using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class SinglePageConfiguration : DbEntityConfiguration<SinglePage>
    {
        public override void Configure(EntityTypeBuilder<SinglePage> entity)
        {
            entity.ToTable("SinglePages");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");
            entity.Property(x => x.Name).IsRequired(true).HasColumnName("Name").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Alias).IsRequired(true).HasColumnName("Alias").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Content).IsRequired(false).HasColumnName("Content").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("int");
        }
    }
}