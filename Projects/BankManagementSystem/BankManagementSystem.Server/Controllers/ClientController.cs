using BankManagementSystem.CQRS.Commands;
using BankManagementSystem.CQRS.Queries;
using BankManagementSystem.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BankManagementSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Client>> CreateClient(CreateClientCommand command)
    {
        var (createdItem, message) = await _mediator.Send(command);
        if(createdItem is null)
            return BadRequest(message);

        return Ok(createdItem);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> GetClientById(Guid id)
    {
        var query = new GetClientByIdQuery() { Id = id };
        var client = await _mediator.Send(query);
        if (client == null)
            return NotFound();

        return Ok(client);
    }

    [HttpGet("AllClients")]
    public async Task<ActionResult<List<Client>>> GetAllClients()
    {
        var query = new GetAllClientsQuery();
        var clients = await _mediator.Send(query);
        return Ok(clients);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<string>> UpdateClient(Guid id, UpdateClientCommand command)
    {
        command.Id = id;
        var (result, message) = await _mediator.Send(command);
        if(result)
            return Ok(message);

        return BadRequest(message);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser(DeleteClientCommand deleteClient)
    {
        var (result, message) = await _mediator.Send(deleteClient);
        if (result)
            return Ok(message);

        return BadRequest(message);
    }
}