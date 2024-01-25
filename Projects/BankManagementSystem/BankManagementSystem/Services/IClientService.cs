using BankManagementSystem.Models;

namespace BankManagementSystem.Services
{
    public interface IClientService
    {
        IEnumerable<Client> GetAll();

        /// <summary>
        /// This is for getting item by Id
        /// </summary>
        /// <param name="id">Id of item</param>
        /// <returns>retruns item if found otherwase null</returns>
        Client GetById(Guid id);
        string Create(Client worker);
        string Update(Guid id, Client item);
        string Delete(Guid id);
    }
}
