using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class FeedbackConfiguration : DbEntityConfiguration<Feedback>
    {
        public override void Configure(EntityTypeBuilder<Feedback> entity)
        {
            entity.ToTable("Feedbacks");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");
            entity.Property(x => x.Name).IsRequired(true).HasColumnName("Name").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Email).IsRequired(false).HasColumnName("Email").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Message).IsRequired(false).HasColumnName("Message").HasColumnType("nvarchar(500)");
            entity.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("int");
            entity.Property(x => x.DateCreated).IsRequired(true).HasColumnName("DateCreated").HasColumnType("varchar(255)");
            entity.Property(x => x.DateModified).IsRequired(true).HasColumnName("DateModified").HasColumnType("varchar(255)");
        }
    }
}