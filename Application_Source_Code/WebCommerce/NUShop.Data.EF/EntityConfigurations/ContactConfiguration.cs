using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;
using NUShop.Data.Enums;
using NUShop.Utilities.Constants;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class ContactConfiguration : DbEntityConfiguration<Contact>

    {
        public override void Configure(EntityTypeBuilder<Contact> entity)
        {
            entity.ToTable("Contacts");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Name).IsRequired(true).HasColumnName("Name").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Phone).IsRequired(false).HasColumnName("Phone").HasColumnType("varchar(50)");
            entity.Property(x => x.Email).IsRequired(false).HasColumnName("Email").HasColumnType("varchar(255)");
            entity.Property(x => x.Email).IsRequired(false).HasColumnName("Email").HasColumnType("varchar(255)");
            entity.Property(x => x.Website).IsRequired(false).HasColumnName("Website").HasColumnType("varchar(255)");
            entity.Property(x => x.Address).IsRequired(false).HasColumnName("Address").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Other).IsRequired(false).HasColumnName("Other").HasColumnType("nvarchar(MAX)");
            entity.Property(x => x.Lat).IsRequired(false).HasColumnName("Lat").HasColumnType("float");
            entity.Property(x => x.Lng).IsRequired(false).HasColumnName("Lng").HasColumnType("float");
            entity.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("int");
            //entity.HasData(new Contact()
            //{
            //    Id = CommonConstants.DefaultFooterId,
            //    Address = "KTX khu B - ĐHQG TPHCM",
            //    Email = "nucasspro26@gmail.com",
            //    Name = "NU Shop",
            //    Phone = "0963209769",
            //    Status = Status.Active,
            //    Website = @"http://nushop.com",
            //    Lat = 21.0435009,
            //    Lng = 105.7894758
            //});
        }
    }
}