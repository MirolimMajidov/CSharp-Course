using AutoMapper;
using BankManagementSystem.CQRS.Queries;
using BankManagementSystem.Models;
using BankManagementSystem.Services;
using MediatR;

namespace BankManagementSystem.CQRS.Handlers;

public class GetClientQueryHandler : IRequestHandler<GetClientByIdQuery, Client>
{
    private IClientService _service;
    private readonly IMapper _mapper;

    public GetClientQueryHandler(IClientService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    public async Task<Client> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        var client = await _service.GetById(request.Id);
        return client;
    }
}