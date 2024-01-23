using BankManagementSystem.Models;

namespace BankManagementSystem.Services
{
    public class WorkerService : IWorkerService
    {
        IWorkerRepository _repository;
        public WorkerService(IWorkerRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Worker> GetAll()
        {
            return _repository.GetAll();
        }

        public Worker GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public string Create(Worker item)
        {
            if (string.IsNullOrEmpty(item.FirstName))
            {
                return "The name cannot be empty";
            }
            else
            {
                _repository.Create(item);
                return $"Created new item with this ID: {item.Id}";
            }
        }

        public string Update(Guid id, Worker item)
        {
            var _item = _repository.GetById(id);
            if (_item is null)
            {
                return "Item not found";
            }
            _repository.Update(_item);
            return "Item updated";
        }

        public string Delete(Guid id)
        {
            var _item = _repository.GetById(id);
            if (_item is null)
            {
                return "Item not found";
            }
            _repository.Delete(id);

            return "Item deleted";
        }
    }
}
