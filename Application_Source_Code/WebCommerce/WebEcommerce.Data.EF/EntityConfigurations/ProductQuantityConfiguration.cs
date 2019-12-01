using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebEcommerce.Data.EF.Extensions;
using WebEcommerce.Data.Entities;

namespace WebEcommerce.Data.EF.EntityConfigurations
{
    public class ProductQuantityConfiguration: DbEntityConfiguration<ProductQuantity>
    {
        public override void Configure(EntityTypeBuilder<ProductQuantity> entity)
        {
            entity.ToTable("ProductQuantities");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");

            entity.Property(x => x.ProductId).IsRequired(true).HasColumnName("ProductId").HasColumnType("int");
            entity.HasOne(x => x.Product).WithMany(y => y.ProductQuantities).HasForeignKey(z => z.ProductId);

            entity.Property(x => x.ProductId).IsRequired(true).HasColumnName("ProductId").HasColumnType("int");
            entity.HasOne(x => x.Product).WithMany(y => y.ProductQuantities).HasForeignKey(z => z.ProductId);

            entity.Property(x => x.SizeId).IsRequired(true).HasColumnName("SizeId").HasColumnType("int");
            entity.HasOne(x => x.Size).WithMany(y => y.ProductQuantities).HasForeignKey(z => z.SizeId);

            entity.Property(x => x.ColorId).IsRequired(true).HasColumnName("ColorId").HasColumnType("int");
            entity.HasOne(x => x.Color).WithMany(y => y.ProductQuantities).HasForeignKey(z => z.ColorId);

            entity.Property(x => x.Quantity).IsRequired(true).HasColumnName("Quantity").HasColumnType("int");
        }
    }
}