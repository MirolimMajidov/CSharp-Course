using BankManagementSystem.Infrastructure;
using BankManagementSystem.Models;

namespace BankManagementSystem.Services
{
    public class SQLRepository<T> : ISQLRepository<T> where T : BaseEntity
    {
        readonly BankContext _context;
        public SQLRepository(BankContext bankContext)
        {
            _context = bankContext;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().SingleOrDefault(w => w.Id == id);
        }

        public bool Create(T item)
        {
            try
            {
                _context.Add(item);
                var result = _context.SaveChanges();
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(T item)
        {
            try
            {
                _context.Update(item);
                var result = _context.SaveChanges();
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                var item = _context.Set<T>().SingleOrDefault(w => w.Id == id);
                if (item is not null)
                {
                    _context.Remove(item);
                    var result = _context.SaveChanges();
                    return result > 0;
                }
            }
            catch
            {}

            return false;
        }
    }
}
