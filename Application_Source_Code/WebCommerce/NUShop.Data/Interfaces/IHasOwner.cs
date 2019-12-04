namespace NUShop.Data.Interfaces
{
    public interface IHasOwner<T>
    {
        T OwnerId { set; get; }
    }
}