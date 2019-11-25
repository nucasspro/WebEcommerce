using WebEcommerce.Model.Enums;

namespace WebEcommerce.Model.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}