using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebEcommerce.Data.EF.Extensions;
using WebEcommerce.Model.Entities;

namespace WebEcommerce.Data.EF.EntityConfigurations
{
    public class BillDetailConfiguration: DbEntityConfiguration<BillDetail>
    {
        public override void Configure(EntityTypeBuilder<BillDetail> entity)
        {
            entity.ToTable("BillDetails");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");

            entity.Property(x => x.BillId).IsRequired(true).HasColumnName("BillId").HasColumnType("int");
            entity.HasOne(x => x.Bill).WithMany(y => y.BillDetails).HasForeignKey(z => z.BillId);

            entity.Property(x => x.ProductId).IsRequired(true).HasColumnName("ProductId").HasColumnType("int");
            entity.HasOne(x => x.Product).WithMany(y => y.BillDetails).HasForeignKey(z => z.ProductId);

            entity.Property(x => x.Quantity).IsRequired(true).HasColumnName("Quantity").HasColumnType("int");
            entity.Property(x => x.Price).IsRequired(true).HasColumnName("Price").HasColumnType("decimal");

            entity.Property(x => x.ColorId).IsRequired(true).HasColumnName("ColorId").HasColumnType("int");
            entity.HasOne(x => x.Color).WithMany(y => y.BillDetails).HasForeignKey(z => z.ColorId);

            entity.Property(x => x.SizeId).IsRequired(true).HasColumnName("SizeId").HasColumnType("int");
            entity.HasOne(x => x.Size).WithMany(y => y.BillDetails).HasForeignKey(z => z.SizeId);
        }
    }
}