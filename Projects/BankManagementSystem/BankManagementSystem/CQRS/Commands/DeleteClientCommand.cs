using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.CQRS.Commands;

public class DeleteClientCommand : IRequest<string>
{
    [FromQuery]
    public Guid Id { get; set; }
}
