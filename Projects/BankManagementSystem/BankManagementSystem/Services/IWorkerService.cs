using BankManagementSystem.Models;

namespace BankManagementSystem.Services
{
    public interface IWorkerService
    {
        IQueryable<Worker> GetAll();
        Worker GetById(Guid id);
        string Create(Worker worker);
        string Update(Guid id, Worker item);
        string Delete(Guid id);
    }
}
