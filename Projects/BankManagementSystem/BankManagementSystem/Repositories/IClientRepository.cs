using BankManagementSystem.Models;

namespace BankManagementSystem.Services
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAll();
        Client GetById(Guid id);
        bool Create(Client item);
        bool Update(Client item);
        bool Delete(Guid id);
    }
}
