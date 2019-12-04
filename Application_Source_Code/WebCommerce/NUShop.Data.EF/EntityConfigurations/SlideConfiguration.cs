using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class SlideConfiguration : DbEntityConfiguration<Slide>
    {
        public override void Configure(EntityTypeBuilder<Slide> entity)
        {
            entity.ToTable("Slides");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");
            entity.Property(x => x.Name).IsRequired(true).HasColumnName("Name").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Description).IsRequired(false).HasColumnName("Description").HasColumnType("text");
            entity.Property(x => x.Image).IsRequired(true).HasColumnName("Image").HasColumnType("varchar(255)");
            entity.Property(x => x.Url).IsRequired(true).HasColumnName("Url").HasColumnType("varchar(255)");
            entity.Property(x => x.DisplayOrder).IsRequired(false).HasColumnName("DisplayOrder").HasColumnType("int");
            entity.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("bit");
            entity.Property(x => x.Content).IsRequired(false).HasColumnName("Content").HasColumnType("text");
            entity.Property(x => x.GroupAlias).IsRequired(true).HasColumnName("GroupAlias").HasColumnType("nvarchar(25)");
            //entity.HasData(
            //    new Slide() { Name = "Slide 1", Image = "/client-side/images/slider/slide-1.jpg", Url = "#", DisplayOrder = 0, GroupAlias = "top", Status = true },
            //    new Slide() { Name = "Slide 2", Image = "/client-side/images/slider/slide-2.jpg", Url = "#", DisplayOrder = 1, GroupAlias = "top", Status = true },
            //    new Slide() { Name = "Slide 3", Image = "/client-side/images/slider/slide-3.jpg", Url = "#", DisplayOrder = 2, GroupAlias = "top", Status = true },
            //    new Slide() { Name = "Slide 1", Image = "/client-side/images/brand1.png", Url = "#", DisplayOrder = 1, GroupAlias = "brand", Status = true },
            //    new Slide() { Name = "Slide 2", Image = "/client-side/images/brand2.png", Url = "#", DisplayOrder = 2, GroupAlias = "brand", Status = true },
            //    new Slide() { Name = "Slide 3", Image = "/client-side/images/brand3.png", Url = "#", DisplayOrder = 3, GroupAlias = "brand", Status = true },
            //    new Slide() { Name = "Slide 4", Image = "/client-side/images/brand4.png", Url = "#", DisplayOrder = 4, GroupAlias = "brand", Status = true },
            //    new Slide() { Name = "Slide 5", Image = "/client-side/images/brand5.png", Url = "#", DisplayOrder = 5, GroupAlias = "brand", Status = true },
            //    new Slide() { Name = "Slide 6", Image = "/client-side/images/brand6.png", Url = "#", DisplayOrder = 6, GroupAlias = "brand", Status = true },
            //    new Slide() { Name = "Slide 7", Image = "/client-side/images/brand7.png", Url = "#", DisplayOrder = 7, GroupAlias = "brand", Status = true },
            //    new Slide() { Name = "Slide 8", Image = "/client-side/images/brand8.png", Url = "#", DisplayOrder = 8, GroupAlias = "brand", Status = true },
            //    new Slide() { Name = "Slide 9", Image = "/client-side/images/brand9.png", Url = "#", DisplayOrder = 9, GroupAlias = "brand", Status = true },
            //    new Slide() { Name = "Slide 10", Image = "/client-side/images/brand10.png", Url = "#", DisplayOrder = 10, GroupAlias = "brand", Status = true },
            //    new Slide() { Name = "Slide 11", Image = "/client-side/images/brand11.png", Url = "#", DisplayOrder = 11, GroupAlias = "brand", Status = true });
        }
    }
}