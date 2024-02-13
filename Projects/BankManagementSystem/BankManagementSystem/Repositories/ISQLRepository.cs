using BankManagementSystem.Models;

namespace BankManagementSystem.Services
{
    public interface ISQLRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        T GetById(Guid id);
        bool Create(T item);
        bool Update(T item);
        bool Delete(Guid id);
    }
}
