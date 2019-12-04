using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class SystemConfigConfiguration : DbEntityConfiguration<SystemConfig>
    {
        public override void Configure(EntityTypeBuilder<SystemConfig> entity)
        {
            entity.ToTable("SystemConfigs");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("varchar(255)");
            entity.Property(x => x.Name).IsRequired(false).HasColumnName("Name").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Value1).IsRequired(false).HasColumnName("Value1").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Value2).IsRequired(false).HasColumnName("Value2").HasColumnType("int");
            entity.Property(x => x.Value3).IsRequired(false).HasColumnName("Value3").HasColumnType("bit");
            entity.Property(x => x.Value5).IsRequired(false).HasColumnName("Value5").HasColumnType("decimal");
            entity.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("int");
        }
    }
}