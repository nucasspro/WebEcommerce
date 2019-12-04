using NUShop.Data.Enums;

namespace NUShop.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}