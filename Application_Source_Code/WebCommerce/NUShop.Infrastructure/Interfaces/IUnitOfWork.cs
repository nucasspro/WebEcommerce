using System;
using System.Threading.Tasks;

namespace NUShop.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        Task CommitAsync();
    }
}