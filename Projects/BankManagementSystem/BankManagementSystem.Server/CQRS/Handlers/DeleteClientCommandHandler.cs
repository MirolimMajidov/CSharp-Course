using AutoMapper;
using BankManagementSystem.CQRS.Commands;
using BankManagementSystem.Services;
using MediatR;

namespace BankManagementSystem.CQRS.Handlers;

public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, string>
{
    private IClientService _service;
    private readonly IMapper _mapper;

    public DeleteClientCommandHandler(IClientService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public Task<string> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var result = _service.Delete(request.Id);
        return Task.FromResult(result);
    }
}
