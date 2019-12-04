using NUShop.Data.Enums;
using NUShop.Data.Interfaces;
using NUShop.Infrastructure.Shared;

namespace NUShop.Data.Entities
{
    public class Language : DomainEntity<string>, ISwitchable
    {
        public Language(string name, bool isDefault, string resources, Status status)
        {
            Name = name;
            IsDefault = isDefault;
            Resources = resources;
            Status = status;
        }

        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public string Resources { get; set; }
        public Status Status { get; set; }
    }
}
