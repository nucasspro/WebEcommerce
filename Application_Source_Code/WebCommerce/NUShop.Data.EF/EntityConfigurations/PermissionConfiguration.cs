using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class PermissionConfiguration : DbEntityConfiguration<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> entity)
        {
            entity.ToTable("Permissions");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");
            entity.Property(x => x.RoleId).IsRequired(true).HasColumnName("RoleId").HasColumnType("uniqueidentifier");
            entity.HasOne(x => x.AppRole).WithMany(y => y.Permissions).HasForeignKey(z => z.RoleId);

            entity.Property(x => x.FunctionId).IsRequired(true).HasColumnName("FunctionId").HasColumnType("nvarchar(255)");
            entity.HasOne(x => x.Function).WithMany(y => y.Permissions).HasForeignKey(z => z.FunctionId);

            entity.Property(x => x.CanCreate).IsRequired(true).HasColumnName("CanCreate").HasColumnType("bit");
            entity.Property(x => x.CanRead).IsRequired(true).HasColumnName("CanRead").HasColumnType("bit"); ;
            entity.Property(x => x.CanUpdate).IsRequired(true).HasColumnName("CanUpdate").HasColumnType("bit"); ;
            entity.Property(x => x.CanDelete).IsRequired(true).HasColumnName("CanDelete").HasColumnType("bit"); ;
        }
    }
}