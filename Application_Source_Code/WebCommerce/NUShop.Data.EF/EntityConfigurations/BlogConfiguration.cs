using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class BlogConfiguration : DbEntityConfiguration<Blog>
    {
        public override void Configure(EntityTypeBuilder<Blog> entity)
        {
            entity.ToTable("Blogs");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");
            entity.Property(x => x.Name).IsRequired(true).HasColumnName("Name").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Image).IsRequired(false).HasColumnName("Image").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Description).IsRequired(false).HasColumnName("Description").HasColumnType("text");
            entity.Property(x => x.Content).IsRequired(false).HasColumnName("Content").HasColumnType("text");
            entity.Property(x => x.HomeFlag).IsRequired(false).HasColumnName("HomeFlag").HasColumnType("bit");
            entity.Property(x => x.HotFlag).IsRequired(false).HasColumnName("HotFlag").HasColumnType("bit");
            entity.Property(x => x.ViewCount).IsRequired(false).HasColumnName("ViewCount").HasColumnType("int");
            entity.Property(x => x.Tags).IsRequired(false).HasColumnName("Tags").HasColumnType("nvarchar(255)");
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