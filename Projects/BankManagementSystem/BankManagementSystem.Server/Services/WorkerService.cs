using BankManagementSystem.Models;

namespace BankManagementSystem.Services
{
    public class WorkerService : IWorkerService
    {
        ISQLRepository<Worker> _repository;
        public WorkerService(ISQLRepository<Worker> repository)
        {
            _repository = repository;
        }

        public IQueryable<Worker> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<Worker> GetMan()
        {
            return _repository.GetAll();
        }

        public async Task<Worker> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public Worker TryCreate(Worker item, out string message)
        {
            if (string.IsNullOrEmpty(item.FirstName) || string.IsNullOrEmpty(item.LastName))
            {
                message = "The first name or last name is be empty";
                return default;
            }
            else
            {
                return _repository.TryCreate(item, out message);
            }
        }

        public bool TryUpdate(Guid id, Worker item, out string message)
        {
            var _item = _repository.GetById(id).GetAwaiter().GetResult();
            if (_item is null)
            {
                message = "Item not found";
                return false;
            }
            else
            {
                _item.FirstName = item.FirstName;
                _item.LastName = item.LastName;
                _item.Birthday = item.Birthday;
                _item.Username = item.Username;
                _item.Password = item.Password;
                _item.Role = item.Role;

                return _repository.TryUpdate(_item, out message);
            }
        }

        public bool TryDelete(Guid id, out string message)
        {
            return _repository.TryDelete(id, out message);
        }
    }
}
