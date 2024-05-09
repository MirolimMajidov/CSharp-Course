using BankManagementSystem.Models;
using BankManagementSystem.Server.Infrastructure;

namespace BankManagementSystem.Services
{
    public interface ISQLRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T> GetById(Guid id);
        T TryCreate(T item, out string message);
        bool TryUpdate(T item, out string message);
        bool TryDelete(Guid id, out string message);
        IBankContext GetContext();
    }
}
