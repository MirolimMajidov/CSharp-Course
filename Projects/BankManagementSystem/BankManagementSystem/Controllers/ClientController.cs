using BankManagementSystem.Models;
using BankManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    readonly IClientService _service;

    public ClientController(IClientService service)
    {
        _service = service;
    }

    [HttpGet("AllItems")]
    public IEnumerable<Client> Get()
    {
        return _service.GetAll();
    }

    [HttpGet("GetItemById")]
    public Client Get(Guid id)
    {
        return _service.GetById(id);
    }

    [HttpPost("Create")]
    public Client Post([FromBody] Client item)
    {
        _service.Create(item);
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
