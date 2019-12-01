using System;
using System.Collections.Generic;
using WebEcommerce.Infrastructure.Shared;
using WebEcommerce.Model.Enums;

namespace WebEcommerce.Data.Entities
{
    public class User : DomainEntity<int>
    {
        public User()
        {

        }

        public string FullName { get; set; }
        public DateTime? BirthDay { set; get; }
        public Status Status { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}