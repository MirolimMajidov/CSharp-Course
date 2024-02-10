
using BankManagementSystem.Infrastructure;
using BankManagementSystem.Models;
using BankManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    readonly IClientService _service;
    readonly BankContext _context;
    public ClientController(IClientService service, BankContext context)
    {
        _service = service;
        _context = context;
    }

    [HttpGet("AllItems")]
    public IEnumerable<Client> Get()
    {
        //return _service.GetAll();
        return _context.Clients;
    }

    [HttpGet("GetItemById")]
    public Client Get(Guid id)
    {
        //return _service.GetById(id);
        return _context.Clients.FirstOrDefault(c => c.Id == id);
    }

    [HttpPost("Create")]
    public Client Post([FromBody] Client item)
    {
        //return _service.Create(item);
        _context.Clients.Add(item);
        _context.SaveChanges();

        return item;
    }

    [HttpPut("Update")]
    public string Put([FromQuery] Guid id, [FromBody] Client item)
    {
        return _service.Update(id, item);
    }

    [HttpDelete("Delete")]
    public string Delete([FromQuery] Guid id)
    {
        return _service.Delete(id);
    }
}
