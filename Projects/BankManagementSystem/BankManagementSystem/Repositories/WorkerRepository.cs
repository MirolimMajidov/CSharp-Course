using BankManagementSystem.Models;

namespace BankManagementSystem.Services
{
    public class WorkerRepository : IWorkerRepository
    {
        static Dictionary<Guid, Worker> Items = new Dictionary<Guid, Worker>();

        public IEnumerable<Worker> GetAll()
        {
            throw new NotImplementedException();
        }

        public Worker GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Create(Worker worker)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Worker item)
        {
            throw new NotImplementedException();
        }
    }
}
