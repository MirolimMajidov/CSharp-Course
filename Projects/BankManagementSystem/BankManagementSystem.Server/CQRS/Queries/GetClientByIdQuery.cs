using BankManagementSystem.Models;
using MediatR;

namespace BankManagementSystem.CQRS.Queries;

public class GetClientByIdQuery : IRequest<Client>
{
    public Guid Id { get; set; }
}
