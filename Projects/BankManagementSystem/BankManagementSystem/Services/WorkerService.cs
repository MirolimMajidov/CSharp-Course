using BankManagementSystem.Models;

namespace BankManagementSystem.Services
{
    public class WorkerService : IWorkerService
    {
        static Dictionary<Guid, Worker> Items = new Dictionary<Guid, Worker>();

        public IEnumerable<Worker> GetAll()
        {
            return Items.Values;
        }

        public Worker GetById(Guid id)
        {
            return Items.SingleOrDefault(w => w.Key == id).Value;
        }

        public string Create(Worker item)
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

        public string Update(Guid id, Worker item)
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
