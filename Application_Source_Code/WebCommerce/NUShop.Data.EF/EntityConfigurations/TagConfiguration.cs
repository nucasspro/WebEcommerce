using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class TagConfiguration : DbEntityConfiguration<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> entity)
        {
            entity.ToTable("Tags");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("varchar(255)");
            entity.Property(x => x.Name).IsRequired(true).HasColumnName("Name").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Type).IsRequired(true).HasColumnName("Type").HasColumnType("nvarchar(255)");
        }
    }
}