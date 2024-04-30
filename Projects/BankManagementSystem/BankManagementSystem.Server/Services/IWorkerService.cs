using BankManagementSystem.Models;

namespace BankManagementSystem.Services
{
    public interface IWorkerService : IBaseService<Worker>
    {
        IQueryable<Worker> GetMan();
    }
}
