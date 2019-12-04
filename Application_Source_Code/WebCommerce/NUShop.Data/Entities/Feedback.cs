using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using NUShop.Data.Enums;
using NUShop.Data.Interfaces;
using NUShop.Infrastructure.Shared;

namespace NUShop.Data.Entities
{
    public class Feedback : DomainEntity<int>,ISwitchable, IDateTracking
    {
        public Feedback() { }

        public Feedback(int id, string name, string email, string message, Status status)
        {
            Id = id;
            Name = name;
            Email = email;
            Message = message;
            Status = status;
        }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Message { set; get; }
        public Status Status { set; get; }
        public string DateCreated { set; get; }
        public string DateModified { set; get; }
    }
}
