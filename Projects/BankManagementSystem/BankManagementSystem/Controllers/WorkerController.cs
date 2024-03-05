using BankManagementSystem.Models;
using BankManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkerController : BaseController<Worker>
{
    public WorkerController(ILogger<WorkerController> logger, IWorkerService service) : base(logger, service)
    {
    }

    [HttpGet("GetMan")]
    public IEnumerable<Worker> GetMan()
    {
        return (_service as IWorkerService).GetMan();
    }
}
