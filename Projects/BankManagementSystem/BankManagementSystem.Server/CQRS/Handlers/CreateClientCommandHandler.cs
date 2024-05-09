using AutoMapper;
using BankManagementSystem.CQRS.Commands;
using BankManagementSystem.Models;
using BankManagementSystem.Services;
using MediatR;

namespace BankManagementSystem.CQRS.Handlers;

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, (Client, string)>
{
    private IClientService _service;
    private readonly IMapper _mapper;

    public CreateClientCommandHandler(IClientService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public Task<(Client, string)> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<Client>(request);
        var createdItem = _service.TryCreate(user, out string message);
        return Task.FromResult((createdItem, message));
    }
}