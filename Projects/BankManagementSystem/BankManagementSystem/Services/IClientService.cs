using BankManagementSystem.Models;

namespace BankManagementSystem.Services
{
    public interface IClientService
    {
        IEnumerable<Client> GetAll();
        Client GetById(Guid id);
        string Create(Client worker);
        string Update(Guid id, Client item);
        string Delete(Guid id);
    }
}
