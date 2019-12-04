using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;
using NUShop.Utilities.Constants;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class FooterConfiguration : DbEntityConfiguration<Footer>
    {
        public override void Configure(EntityTypeBuilder<Footer> entity)
        {
            entity.ToTable("Footers");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("varchar(255)");
            entity.Property(x => x.Content).IsRequired(true).HasColumnName("Content").HasColumnType("nvarchar(255)");
            //entity.HasData(new Footer() { Id = CommonConstants.DefaultFooterId, Content = "Footer" });
        }
    }
}