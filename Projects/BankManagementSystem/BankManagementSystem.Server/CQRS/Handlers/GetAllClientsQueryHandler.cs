using AutoMapper;
using BankManagementSystem.CQRS.Queries;
using BankManagementSystem.Models;
using BankManagementSystem.Services;
using MediatR;

namespace BankManagementSystem.CQRS.Handlers;

public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, List<Client>>
{
    private IClientService _service;
    private readonly IMapper _mapper;

    public GetAllClientsQueryHandler(IClientService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<List<Client>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
    {
        var clients = _service.GetAll().ToList();
        return await Task.FromResult(clients);
    }
}
