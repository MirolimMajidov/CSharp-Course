using BankManagementSystem.Models;
using BankManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkerController : ControllerBase
{
    readonly IWorkerService _service;
    public WorkerController(IWorkerService service)
    {
        _service = service;
    }

    [HttpGet("AllItems")]
    public IEnumerable<Worker> Get()
    {
        return _service.GetAll();
    }

    [HttpGet("GetItemById")]
    public Worker Get(Guid id)
    {
        return _service.GetById(id);
    }

    [HttpPost("Create")]
    public string Post([FromBody] Worker item)
    {
        return _service.Create(item);
    }

    [HttpPut("Update")]
    public string Put([FromQuery] Guid id, [FromBody] Worker item)
    {
        return _service.Update(id, item);
    }

    [HttpDelete("Delete")]
    public string Delete([FromQuery] Guid id)
    {
        return _service.Delete(id);
    }
}
