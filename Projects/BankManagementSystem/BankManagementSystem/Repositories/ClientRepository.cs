using BankManagementSystem.Models;

namespace BankManagementSystem.Services
{
    public class ClientRepository : IClientRepository
    {
        Dictionary<Guid, Client> _items = new Dictionary<Guid, Client>();

        public IEnumerable<Client> GetAll()
        {
            return _items.Values;
        }

        public Client GetById(Guid id)
        {
            return _items.SingleOrDefault(w => w.Key == id).Value;
        }

        public bool Create(Client item)
        {
           return _items.TryAdd(item.Id, item);
        }

        public bool Update(Client item)
        {
            try
            {
                _items[item.Id] = item;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Delete(Guid id)
        {
            return _items.Remove(id);
        }
    }
}
