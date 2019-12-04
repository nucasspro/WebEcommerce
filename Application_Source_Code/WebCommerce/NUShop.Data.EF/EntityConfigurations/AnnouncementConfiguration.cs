using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class AnnouncementConfiguration : DbEntityConfiguration<Announcement>
    {
        public override void Configure(EntityTypeBuilder<Announcement> entity)
        {
            entity.ToTable("Announcements");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("varchar(255)");
            entity.Property(x => x.Title).IsRequired(true).HasColumnName("Title").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Content).IsRequired(false).HasColumnName("Content").HasColumnType("nvarchar(255)");

            entity.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("int");
            entity.Property(x => x.DateCreated).IsRequired(true).HasColumnName("DateCreated").HasColumnType("varchar(255)");
            entity.Property(x => x.DateModified).IsRequired(true).HasColumnName("DateModified").HasColumnType("varchar(255)");
        }
    }
}