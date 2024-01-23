using BankManagementSystem.Models;

namespace BankManagementSystem.Services
{
    public interface IWorkerRepository
    {
        IEnumerable<Worker> GetAll();
        Worker GetById(Guid id);
        bool Create(Worker worker);
        bool Update(Worker item);
        bool Delete(Guid id);
    }
}
