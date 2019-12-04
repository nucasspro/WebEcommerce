using NUShop.Infrastructure.Shared;
using System;

namespace NUShop.Data.Entities
{
    public class Permission : DomainEntity<int>
    {
        public Permission()
        {
        }

        public Permission(Guid roleId, string functionId, bool canCreate,
            bool canRead, bool canUpdate, bool canDelete)
        {
            RoleId = roleId;
            FunctionId = functionId;
            CanCreate = canCreate;
            CanRead = canRead;
            CanUpdate = canUpdate;
            CanDelete = canDelete;
        }

        public Guid RoleId { get; set; }
        public virtual AppRole AppRole { get; set; }

        public string FunctionId { get; set; }
        public virtual Function Function { get; set; }

        public bool CanCreate { set; get; }
        public bool CanRead { set; get; }
        public bool CanUpdate { set; get; }
        public bool CanDelete { set; get; }
    }
}