using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;
using NUShop.Data.Enums;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class FunctionConfiguration : DbEntityConfiguration<Function>

    {
        public override void Configure(EntityTypeBuilder<Function> entity)
        {
            entity.ToTable("Functions");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Name).IsRequired(true).HasColumnName("Name").HasColumnType("nvarchar(255)");
            entity.Property(x => x.URL).IsRequired(true).HasColumnName("URL").HasColumnType("nvarchar(255)");
            entity.Property(x => x.ParentId).IsRequired(false).HasColumnName("ParentId").HasColumnType("nvarchar(255)");
            entity.Property(x => x.IconCss).IsRequired(false).HasColumnName("IconCss").HasColumnType("varchar(MAX)");
            entity.Property(x => x.SortOrder).IsRequired(true).HasColumnName("SortOrder").HasColumnType("int");
            entity.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("int");
            //entity.HasData(
            //    new Function() { Id = "SYSTEM", Name = "System", ParentId = null, SortOrder = 1, Status = Status.Active, URL = "/", IconCss = "fa-desktop" },
            //    new Function() { Id = "ROLE", Name = "Role", ParentId = "SYSTEM", SortOrder = 1, Status = Status.Active, URL = "/admin/role/index", IconCss = "fa-home" },
            //    new Function() { Id = "FUNCTION", Name = "Function", ParentId = "SYSTEM", SortOrder = 2, Status = Status.Active, URL = "/admin/function/index", IconCss = "fa-home" },
            //    new Function() { Id = "USER", Name = "User", ParentId = "SYSTEM", SortOrder = 3, Status = Status.Active, URL = "/admin/user/index", IconCss = "fa-home" },
            //    new Function() { Id = "ACTIVITY", Name = "Activity", ParentId = "SYSTEM", SortOrder = 4, Status = Status.Active, URL = "/admin/activity/index", IconCss = "fa-home" },
            //    new Function() { Id = "ERROR", Name = "Error", ParentId = "SYSTEM", SortOrder = 5, Status = Status.Active, URL = "/admin/error/index", IconCss = "fa-home" },
            //    new Function() { Id = "SETTING", Name = "Configuration", ParentId = "SYSTEM", SortOrder = 6, Status = Status.Active, URL = "/admin/setting/index", IconCss = "fa-home" },
            //    new Function() { Id = "PRODUCT", Name = "Product Management", ParentId = null, SortOrder = 2, Status = Status.Active, URL = "/", IconCss = "fa-chevron-down" },
            //    new Function() { Id = "CATEGORY", Name = "Category", ParentId = "PRODUCT", SortOrder = 1, Status = Status.Active, URL = "/admin/category/index", IconCss = "fa-chevron-down" },
            //    new Function() { Id = "PRODUCT_LIST", Name = "Product", ParentId = "PRODUCT", SortOrder = 2, Status = Status.Active, URL = "/admin/product/index", IconCss = "fa-chevron-down" },
            //    new Function() { Id = "BILL", Name = "Bill", ParentId = "PRODUCT", SortOrder = 3, Status = Status.Active, URL = "/admin/bill/index", IconCss = "fa-chevron-down" },
            //    new Function() { Id = "CONTENT", Name = "Content", ParentId = null, SortOrder = 3, Status = Status.Active, URL = "/", IconCss = "fa-table" },
            //    new Function() { Id = "BLOG", Name = "Blog", ParentId = "CONTENT", SortOrder = 1, Status = Status.Active, URL = "/admin/blog/index", IconCss = "fa-table" },
            //    new Function() { Id = "PAGE", Name = "Page", ParentId = "CONTENT", SortOrder = 2, Status = Status.Active, URL = "/admin/page/index", IconCss = "fa-table" },
            //    new Function() { Id = "UTILITY", Name = "Utilities", ParentId = null, SortOrder = 4, Status = Status.Active, URL = "/", IconCss = "fa-clone" },
            //    new Function() { Id = "FOOTER", Name = "Footer", ParentId = "UTILITY", SortOrder = 1, Status = Status.Active, URL = "/admin/footer/index", IconCss = "fa-clone" },
            //    new Function() { Id = "FEEDBACK", Name = "Feedback", ParentId = "UTILITY", SortOrder = 2, Status = Status.Active, URL = "/admin/feedback/index", IconCss = "fa-clone" },
            //    new Function() { Id = "ANNOUNCEMENT", Name = "Announcement", ParentId = "UTILITY", SortOrder = 3, Status = Status.Active, URL = "/admin/announcement/index", IconCss = "fa-clone" },
            //    new Function() { Id = "CONTACT", Name = "Contact", ParentId = "UTILITY", SortOrder = 4, Status = Status.Active, URL = "/admin/contact/index", IconCss = "fa-clone" },
            //    new Function() { Id = "SLIDE", Name = "Slide", ParentId = "UTILITY", SortOrder = 5, Status = Status.Active, URL = "/admin/slide/index", IconCss = "fa-clone" },
            //    new Function() { Id = "ADVERTISMENT", Name = "Advertisment", ParentId = "UTILITY", SortOrder = 6, Status = Status.Active, URL = "/admin/advertistment/index", IconCss = "fa-clone" },
            //    new Function() { Id = "REPORT", Name = "Report", ParentId = null, SortOrder = 5, Status = Status.Active, URL = "/", IconCss = "fa-bar-chart-o" },
            //    new Function() { Id = "REVENUES", Name = "Revenue report", ParentId = "REPORT", SortOrder = 1, Status = Status.Active, URL = "/admin/report/revenues", IconCss = "fa-bar-chart-o" },
            //    new Function() { Id = "ACCESS", Name = "Visitor Report", ParentId = "REPORT", SortOrder = 2, Status = Status.Active, URL = "/admin/report/visitor", IconCss = "fa-bar-chart-o" },
            //    new Function() { Id = "READER", Name = "Reader Report", ParentId = "REPORT", SortOrder = 3, Status = Status.Active, URL = "/admin/report/reader", IconCss = "fa-bar-chart-o" });
        }
    }
}