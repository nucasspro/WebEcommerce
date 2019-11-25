using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebEcommerce.Data.EF.Extensions;
using  WebEcommerce.Model.Entities;

namespace WebEcommerce.Data.EF.EntityConfigurations
{
    public class SizeConfiguration: DbEntityConfiguration<Size>
    {
        public override void Configure(EntityTypeBuilder<Size> entity)
        {
            entity.ToTable("Sizes");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");
            entity.Property(x => x.Name).IsRequired(false).HasColumnName("Name").HasColumnType("nvarchar(255)");
        }
    }
}