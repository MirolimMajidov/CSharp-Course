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
        /// <returns>retruns item if found otherwase null</returns>
        TEntity GetById(Guid id);

        string Create(TEntity worker);

        string Update(Guid id, TEntity item);

        string Delete(Guid id);
    }
}
