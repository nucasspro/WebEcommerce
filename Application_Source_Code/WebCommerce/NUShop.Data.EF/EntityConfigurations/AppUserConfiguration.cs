using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;
using NUShop.Data.Enums;
using NUShop.Utilities.Helpers;
using System;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class AppUserConfiguration : DbEntityConfiguration<AppUser>
    {
        private string dateTime = ConvertDatetime.ConvertToTimeSpan(DateTime.Now);
        public override void Configure(EntityTypeBuilder<AppUser> entity)
        {
            entity.ToTable("AppUsers");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.FullName).IsRequired(false).HasColumnName("FullName").HasColumnType("nvarchar(255)");
            entity.Property(x => x.BirthDay).IsRequired(false).HasColumnName("BirthDay").HasColumnType("datetime");
            entity.Property(x => x.Balance).IsRequired(true).HasColumnName("Balance").HasColumnType("decimal");
            entity.Property(x => x.Avatar).IsRequired(false).HasColumnName("Avatar").HasColumnType("nvarchar(MAX)");
            entity.Property(x => x.DateCreated).IsRequired(true).HasColumnName("DateCreated").HasColumnType("varchar(255)");
            entity.Property(x => x.DateModified).IsRequired(true).HasColumnName("DateModified").HasColumnType("varchar(255)");
            entity.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("int");
        }
    }
}