using BankManagementSystem.Models;
using BankManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkerController : BaseController<Worker>
{
    public WorkerController(ILogger<WorkerController> logger, IWorkerService service) : base(logger, service)
    {
    }

    [AllowAnonymous]
    [HttpGet("GetMan")]
    public IEnumerable<Worker> GetMan()
    {
        return (_service as IWorkerService).GetMan();
    }

    [AllowAnonymous]
    [HttpPost("Create")]
    public override ActionResult<Worker> Post([FromBody] Worker item)
    {
        return base.Post(item);
    }
}
