using BankManagementSystem.Models;

namespace BankManagementSystem.Services
{
    public class MemoryRepository<T> : IMemoryRepository<T> where T : BaseEntity
    {
        Dictionary<Guid, T> _items = new Dictionary<Guid, T>();

        public IEnumerable<T> GetAll()
        {
            return _items.Values;
        }

        public T GetById(Guid id)
        {
            return _items.SingleOrDefault(w => w.Key == id).Value;
        }

        public bool Create(T item)
        {
            return _items.TryAdd(item.Id, item);
        }

        public bool Update(T item)
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
