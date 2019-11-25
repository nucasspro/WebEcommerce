using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebEcommerce.Data.EF.Extensions;
using WebEcommerce.Model.Entities;

namespace WebEcommerce.Data.EF.EntityConfigurations
{
    public class ProductConfiguration: DbEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable("Products");
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");
            entity.Property(x => x.Name).IsRequired(true).HasColumnName("Name").HasColumnType("nvarchar(255)");

            entity.Property(x => x.CategoryId).IsRequired(true).HasColumnName("CategoryId").HasColumnType("int");
            entity.HasOne(x => x.Category).WithMany(y => y.Products).HasForeignKey(z => z.CategoryId);

            entity.Property(x => x.Image).IsRequired(false).HasColumnName("Image").HasColumnType("varchar(255)");
            entity.Property(x => x.Price).IsRequired(true).HasColumnName("Price").HasColumnType("decimal").HasDefaultValue(0);
            entity.Property(x => x.PromotionPrice).IsRequired(false).HasColumnName("PromotionPrice").HasColumnType("decimal");
            entity.Property(x => x.OriginalPrice).IsRequired(true).HasColumnName("OriginalPrice").HasColumnType("decimal");
            entity.Property(x => x.Description).IsRequired(false).HasColumnName("Description").HasColumnType("text");
            entity.Property(x => x.Content).IsRequired(false).HasColumnName("Content").HasColumnType("text");
            entity.Property(x => x.HomeFlag).IsRequired(false).HasColumnName("HomeFlag").HasColumnType("bit");
            entity.Property(x => x.HotFlag).IsRequired(false).HasColumnName("HotFlag").HasColumnType("bit");
            entity.Property(x => x.ViewCount).IsRequired(false).HasColumnName("ViewCount").HasColumnType("int");
            entity.Property(x => x.Tags).IsRequired(false).HasColumnName("Tags").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Unit).IsRequired(false).HasColumnName("Unit").HasColumnType("nvarchar(255)");

            entity.Property(x => x.SeoPageTitle).IsRequired(false).HasColumnName("SeoPageTitle").HasColumnType("nvarchar(255)");
            entity.Property(x => x.SeoAlias).IsRequired(false).HasColumnName("SeoAlias").HasColumnType("nvarchar(255)");
            entity.Property(x => x.SeoKeywords).IsRequired(false).HasColumnName("SeoKeywords").HasColumnType("nvarchar(255)");
            entity.Property(x => x.SeoDescription).IsRequired(false).HasColumnName("SeoDescription").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("int");
            entity.Property(x => x.DateCreated).IsRequired(true).HasColumnName("DateCreated").HasColumnType("varchar(255)");
            entity.Property(x => x.DateModified).IsRequired(true).HasColumnName("DateModified").HasColumnType("varchar(255)");
        }
    }
}