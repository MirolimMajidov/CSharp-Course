using BankManagementSystem.Models;

namespace BankManagementSystem.Services
{
    public class ClientService : IClientService
    {
        ISQLRepository<Client> _repository;
        public ClientService(ISQLRepository<Client> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Client> GetAll()
        {
            return _repository.GetAll();
        }

        public Client GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public string Create(Client item)
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

        public string Update(Guid id, Client item)
        {
            var _item = _repository.GetById(id);
            if (_item is not null)
            {
                _item.FirstName = item.FirstName;
                _item.Name = item.Name;
                _item.Birthday = item.Birthday;
                _item.State = item.State;

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
