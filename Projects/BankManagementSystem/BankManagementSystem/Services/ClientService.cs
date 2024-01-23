using BankManagementSystem.Models;

namespace BankManagementSystem.Services
{
    public class ClientService : IClientService
    {
        static Dictionary<Guid, Client> Items = new Dictionary<Guid, Client>();

        public IEnumerable<Client> GetAll()
        {
            return Items.Values;
        }

        public Client GetById(Guid id)
        {
            return Items.SingleOrDefault(w => w.Key == id).Value;
        }

        public string Create(Client item)
        {
            if (string.IsNullOrEmpty(item.FirstName))
            {
                return "The name cannot be empty";
            }
            else
            {
                Items.Add(item.Id, item);
                return $"Created new item with this ID: {item.Id}";
            }
        }

        public string Update(Guid id, Client item)
        {
            var _item = Items.SingleOrDefault(w => w.Key == id).Value;
            if (_item is null)
            {
                return "Item not found";
            }
            _item.FirstName = item.FirstName;
            _item.LastName = item.LastName;
            _item.Birthday = item.Birthday;
            return "Item updated";
        }

        public string Delete(Guid id)
        {
            var _item = Items.SingleOrDefault(w => w.Key == id).Value;
            if (_item is null)
            {
                return "Item not found";
            }
            Items.Remove(id);

            return "Item deleted";
        }
    }
}
