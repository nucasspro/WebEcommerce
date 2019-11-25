namespace WebEcommerce.Model.Interfaces
{
    public interface IDateTracking
    {
        string DateCreated { set; get; }
        string DateModified { set; get; }
    }
}