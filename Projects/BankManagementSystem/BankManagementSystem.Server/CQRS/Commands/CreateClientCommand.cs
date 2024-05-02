using BankManagementSystem.Models;
using MediatR;

namespace BankManagementSystem.CQRS.Commands;

public class CreateClientCommand : IRequest<Client>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public Guid? BranchId { get; set; }
}