using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class ProductTagConfiguration : DbEntityConfiguration<ProductTag>
    {
        public override void Configure(EntityTypeBuilder<ProductTag> entity)
        {
            entity.ToTable("ProductTags");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");

            entity.Property(x => x.ProductId).IsRequired(true).HasColumnName("ProductId").HasColumnType("int");
            entity.HasOne(x => x.Product).WithMany(y => y.ProductTags).HasForeignKey(z => z.ProductId);

            entity.Property(x => x.TagId).IsRequired(true).HasColumnName("TagId").HasColumnType("varchar(255)");
            entity.HasOne(x => x.Tag).WithMany(y => y.ProductTags).HasForeignKey(z => z.TagId);
        }
    }
}