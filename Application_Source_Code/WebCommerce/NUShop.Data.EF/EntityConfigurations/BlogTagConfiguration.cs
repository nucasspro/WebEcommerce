using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class BlogTagConfiguration : DbEntityConfiguration<BlogTag>
    {
        public override void Configure(EntityTypeBuilder<BlogTag> entity)
        {
            entity.ToTable("BlogTags");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");

            entity.Property(x => x.BlogId).IsRequired(true).HasColumnName("BlogId").HasColumnType("int");
            entity.HasOne(x => x.Blog).WithMany(y => y.BlogTags).HasForeignKey(z => z.BlogId);

            entity.Property(x => x.TagId).IsRequired(true).HasColumnName("TagId").HasColumnType("varchar(255)");
            entity.HasOne(x => x.Tag).WithMany(y => y.BlogTags).HasForeignKey(z => z.TagId);
        }
    }
}