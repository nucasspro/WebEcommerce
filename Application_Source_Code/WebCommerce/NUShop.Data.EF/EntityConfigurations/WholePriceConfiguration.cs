using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class WholePriceConfiguration : DbEntityConfiguration<WholePrice>
    {
        public override void Configure(EntityTypeBuilder<WholePrice> entity)
        {
            entity.ToTable("WholePrices");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");

            entity.Property(x => x.ProductId).IsRequired(true).HasColumnName("ProductId").HasColumnType("int");
            entity.HasOne(x => x.Product).WithMany(y => y.WholePrices).HasForeignKey(z => z.ProductId);

            entity.Property(x => x.FromQuantity).IsRequired(true).HasColumnName("FromQuantity").HasColumnType("int");
            entity.Property(x => x.ToQuantity).IsRequired(true).HasColumnName("ToQuantity").HasColumnType("int");
            entity.Property(x => x.Price).IsRequired(true).HasColumnName("Price").HasColumnType("decimal");
        }
    }
}