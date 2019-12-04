using NUShop.Data.Enums;
using NUShop.Data.Interfaces;
using NUShop.Infrastructure.Shared;
using System.Collections.Generic;

namespace NUShop.Data.Entities
{
    public class Function : DomainEntity<string>, ISwitchable, ISortable
    {
        public Function()
        {
            Permissions = new List<Permission>();
        }

        public Function(string name, string url, string parentId, string iconCss, int sortOrder)
        {
            Name = name;
            URL = url;
            ParentId = parentId;
            IconCss = iconCss;
            SortOrder = sortOrder;
            Status = Status.Active;
        }

        public string Name { set; get; }
        public string URL { set; get; }
        public string ParentId { set; get; }
        public string IconCss { get; set; }
        public int SortOrder { set; get; }
        public Status Status { set; get; }
        public virtual ICollection<Permission> Permissions  { get; set; }
    }
}