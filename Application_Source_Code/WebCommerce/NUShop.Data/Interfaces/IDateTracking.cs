using System;

namespace NUShop.Data.Interfaces
{
    public interface IDateTracking
    {
        string DateCreated { set; get; }
        string DateModified { set; get; }
    }
}