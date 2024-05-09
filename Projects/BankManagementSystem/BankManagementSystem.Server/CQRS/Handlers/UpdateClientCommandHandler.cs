using AutoMapper;
using BankManagementSystem.CQRS.Commands;
using BankManagementSystem.Models;
using BankManagementSystem.Services;
using MediatR;

namespace BankManagementSystem.CQRS.Handlers;
public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, (bool, string)>
{
    private IClientService _service;
    private readonly IMapper _mapper;

    public UpdateClientCommandHandler(IClientService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public Task<(bool, string)> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var client = _mapper.Map<Client>(request);
        var result = _service.TryUpdate(request.Id, client, out string message);
        return Task.FromResult((result, message));
    }
}