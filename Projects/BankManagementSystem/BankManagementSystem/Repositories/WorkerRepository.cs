﻿using BankManagementSystem.Models;

namespace BankManagementSystem.Services
{
    public class WorkerRepository : IWorkerRepository
    {
        Dictionary<Guid, Worker> _items = new Dictionary<Guid, Worker>();

        public IEnumerable<Worker> GetAll()
        {
            return _items.Values;
        }

        public Worker GetById(Guid id)
        {
            return _items.SingleOrDefault(w => w.Key == id).Value;
        }

        public bool Create(Worker worker)
        {
           return _items.TryAdd(worker.Id, worker);
        }

        public bool Update(Worker item)
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