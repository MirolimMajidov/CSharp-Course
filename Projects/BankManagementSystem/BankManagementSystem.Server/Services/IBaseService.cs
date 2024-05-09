using BankManagementSystem.Models;

namespace BankManagementSystem.Services
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// This is for getting item by Id
        /// </summary>
        /// <param name="id">Id of item</param>
        /// <returns>returns item if found otherwise null</returns>
        Task<TEntity> GetById(Guid id);

        TEntity TryCreate(TEntity worker, out string message);

        bool TryUpdate(Guid id, TEntity item, out string message);

        bool TryDelete(Guid id, out string message);
    }
}
