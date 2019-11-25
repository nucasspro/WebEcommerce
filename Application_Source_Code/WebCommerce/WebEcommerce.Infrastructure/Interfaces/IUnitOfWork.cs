using System;
using System.Threading.Tasks;

namespace WebEcommerce.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        Task CommitAsync();
    }
}