using BankManagementSystem.Models;
using MediatR;

namespace BankManagementSystem.CQRS.Queries;


public class GetAllClientsQuery : IRequest<List<Client>>
{
}
