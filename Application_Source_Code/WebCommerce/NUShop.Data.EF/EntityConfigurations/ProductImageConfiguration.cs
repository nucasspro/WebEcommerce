using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class ProductImageConfiguration : DbEntityConfiguration<ProductImage>
    {
        public override void Configure(EntityTypeBuilder<ProductImage> entity)
        {
            entity.ToTable("ProductImages");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");

            entity.Property(x => x.ProductId).IsRequired(true).HasColumnName("ProductId").HasColumnType("int");
            entity.HasOne(x => x.Product).WithMany(y => y.ProductImages).HasForeignKey(z => z.ProductId);

            entity.Property(x => x.Path).IsRequired(false).HasColumnName("Path").HasColumnType("varchar(255)");
            entity.Property(x => x.Caption).IsRequired(false).HasColumnName("Caption").HasColumnType("varchar(255)");
        }
    }
}