using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebEcommerce.Data.EF.Extensions;
using WebEcommerce.Data.Entities;

namespace WebEcommerce.Data.EF.EntityConfigurations
{
    public class CategoryConfiguration: DbEntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.ToTable("Categories");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");
            entity.Property(x => x.Name).IsRequired(false).HasColumnName("Name").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Description).IsRequired(false).HasColumnName("Description").HasColumnType("nvarchar(MAX)");
            entity.Property(x => x.ParentId).IsRequired(false).HasColumnName("ParentId").HasColumnType("int");
            entity.Property(x => x.HomeOrder).IsRequired(false).HasColumnName("HomeOrder").HasColumnType("int");
            entity.Property(x => x.HomeFlag).IsRequired(false).HasColumnName("HomeFlag").HasColumnType("bit");
            entity.Property(x => x.Image).IsRequired(false).HasColumnName("Image").HasColumnType("varchar(255)");
            entity.Property(x => x.SortOrder).IsRequired(true).HasColumnName("SortOrder").HasColumnType("int");
            entity.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("int");
            entity.Property(x => x.DateCreated).IsRequired(true).HasColumnName("DateCreated").HasColumnType("varchar(255)");
            entity.Property(x => x.DateModified).IsRequired(true).HasColumnName("DateModified").HasColumnType("varchar(255)");
        }
    }
}