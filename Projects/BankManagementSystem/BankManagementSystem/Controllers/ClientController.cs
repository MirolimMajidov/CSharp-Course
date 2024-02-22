using BankManagementSystem.Models;
using BankManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;

namespace BankManagementSystem.Controllers;

[ApiController]
[Route("MyClient")]
public class ClientController : ControllerBase
{
    readonly IClientService _service;
    readonly ILogger<ClientController> _logger;

    public ClientController(ILogger<ClientController> logger, IClientService service)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Client>), (int)HttpStatusCode.OK)]
    public IActionResult Get()
    {
        _logger.LogDebug("API started...");
        try
        {
            throw new Exception("Test exception");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Started Exception...{ex.Message}");
        }

        _logger.LogInformation("API finished...");

        return Ok(_service.GetAll());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Client), (int)HttpStatusCode.OK)]
    public IActionResult Get(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return Ok(_service.GetById(id));
    }

    [HttpPost]
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
