using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class AnnouncementUserConfiguration : DbEntityConfiguration<AnnouncementUser>
    {
        public override void Configure(EntityTypeBuilder<AnnouncementUser> entity)
        {
            entity.ToTable("AnnouncementUsers");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");

            entity.Property(x => x.AnnouncementId).IsRequired(true).HasColumnName("AnnouncementId").HasColumnType("varchar(255)");
            entity.HasOne(x => x.Announcement).WithMany(y => y.AnnouncementUsers).HasForeignKey(z => z.AnnouncementId);

            entity.Property(x => x.UserId).IsRequired(true).HasColumnName("UserId").HasColumnType("uniqueidentifier");
            entity.HasOne(x => x.AppUser).WithMany(y => y.AnnouncementUsers).HasForeignKey(z => z.UserId);

            entity.Property(x => x.HasRead).IsRequired(false).HasColumnName("HasRead").HasColumnType("bit");
        }
    }
}