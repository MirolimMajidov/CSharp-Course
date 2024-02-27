using BankManagementSystem.Models;
using BankManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;

namespace BankManagementSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : BaseController<Client>
{
    public ClientController(ILogger<ClientController> logger, IClientService service) : base(logger, service)
    {
    }
}