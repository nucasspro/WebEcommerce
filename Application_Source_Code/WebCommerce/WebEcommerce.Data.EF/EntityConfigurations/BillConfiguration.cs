using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebEcommerce.Data.EF.Extensions;
using WebEcommerce.Data.Entities;
using WebEcommerce.Model.Enums;

namespace WebEcommerce.Data.EF.EntityConfigurations
{
    public class BillConfiguration : DbEntityConfiguration<Bill>
    {
        public override void Configure(EntityTypeBuilder<Bill> entity)
        {
            entity.ToTable("Bills");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");
            entity.Property(x => x.CustomerName).IsRequired(true).HasColumnName("CustomerName").HasColumnType("nvarchar(255)");
            entity.Property(x => x.CustomerAddress).IsRequired(true).HasColumnName("CustomerAddress").HasColumnType("nvarchar(255)");
            entity.Property(x => x.CustomerMobile).IsRequired(true).HasColumnName("CustomerMobile").HasColumnType("nvarchar(255)");
            entity.Property(x => x.CustomerMessage).IsRequired(false).HasColumnName("CustomerMessage").HasColumnType("nvarchar(255)");
            entity.Property(x => x.PaymentMethod).IsRequired(true).HasColumnName("PaymentMethod").HasColumnType("int");
            entity.Property(x => x.BillStatus).IsRequired(true).HasColumnName("BillStatus").HasColumnType("int");
            entity.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("int").HasDefaultValue(Status.Active);
            entity.Property(x => x.DateCreated).IsRequired(true).HasColumnName("DateCreated").HasColumnType("varchar(255)");
            entity.Property(x => x.DateModified).IsRequired(true).HasColumnName("DateModified").HasColumnType("varchar(255)");

            entity.Property(x => x.UserId).IsRequired(false).HasColumnName("UserId").HasColumnType("int");
            entity.HasOne(x => x.User).WithMany(y => y.Bills).HasForeignKey(z => z.UserId);
        }
    }
}