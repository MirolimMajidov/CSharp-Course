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

        public IQueryable<Client> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<Client> GetAll(int skip, int take)
        {
            return _repository.GetAll().Skip(skip).Take(take);
        }

        public async Task<Client> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public Client TryCreate(Client item, out string message)
        {
            if (string.IsNullOrEmpty(item.FirstName) || string.IsNullOrEmpty(item.LastName))
            {
                message = "The first name or last name is be empty";
                return default;
            }

            var branch = _repository.GetContext().GetEntities<Branch>().FirstOrDefault(b => b.Id == item.BranchId);
            if (branch is null)
            {
                message = "There is no branch with the passing Id";
                return default;
            }

            return _repository.TryCreate(item, out message);
        }

        public bool TryUpdate(Guid id, Client item, out string message)
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
