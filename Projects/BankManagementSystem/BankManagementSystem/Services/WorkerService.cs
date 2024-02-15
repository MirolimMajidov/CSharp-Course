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
            if (_item is not null)
            {
                _item.FirstName = item.FirstName;
                _item.LastName = item.LastName;
                _item.Birthday = item.Birthday;
                _item.Role = item.Role;

                var result = _repository.Update(_item);
                if (result)
                    return "Item updated";
            }

            return "Item not updated";
        }

        public string Delete(Guid id)
        {
            var result = _repository.Delete(id);
            if (result)
                return "Item deleted";
            else
                return "Item not found";
        }
    }
}
