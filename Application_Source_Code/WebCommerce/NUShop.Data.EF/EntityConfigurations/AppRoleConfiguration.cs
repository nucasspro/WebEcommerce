using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class AppRoleConfiguration : DbEntityConfiguration<AppRole>
    {
        public override void Configure(EntityTypeBuilder<AppRole> entity)
        {
            entity.ToTable("AppRoles");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("uniqueidentifier");
            entity.Property(x => x.Name).IsRequired(false).HasColumnName("Name").HasColumnType("nvarchar(MAX)");
            entity.Property(x => x.Description).IsRequired(false).HasColumnName("Description").HasColumnType("nvarchar(255)");
            //entity.HasData(
            //    new AppRole { Name = "Admin", NormalizedName = "Admin", Description = "Top manager" },
            //    new AppRole { Name = "Staff", NormalizedName = "Staff", Description = "Staff" },
            //    new AppRole { Name = "Customer", NormalizedName = "Customer", Description = "Customer" });
        }
    }
}