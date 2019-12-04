using NUShop.Data.Enums;
using NUShop.Data.Interfaces;
using NUShop.Infrastructure.Shared;
using System;

namespace NUShop.Data.Entities
{
    public class SystemConfig : DomainEntity<string>, ISwitchable
    {
        public SystemConfig()
        {
        }

        public SystemConfig(string name, string value1, int? value2, 
            bool? value3, DateTime? value4, decimal? value5, Status status)
        {
            Name = name;
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
            Value4 = value4;
            Value5 = value5;
            Status = status;
        }

        public string Name { get; set; }
        public string Value1 { get; set; }
        public int? Value2 { get; set; }
        public bool? Value3 { get; set; }
        public DateTime? Value4 { get; set; }
        public decimal? Value5 { get; set; }
        public Status Status { get; set; }
    }
}
