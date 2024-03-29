using BankManagementSystem.Infrastructure;
using BankManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace BankManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BranchController : ControllerBase
    {
        private readonly ILogger<BranchController> _logger;
        private readonly BankContext _context;

        public BranchController(ILogger<BranchController> logger, BankContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Branch> Get(CancellationToken cancellationToken)
        {
            var context = HttpContext.RequestServices.GetService<BankContext>();
            using var transuction = _context.Database.BeginTransaction();
            try
            {
                //TODO: Some changes
                var client = new Client()
                {
                    FirstName = "Rahmatillo"
                };
                _context.Add(client);
                _context.SaveChanges();

                var storedClient = _context.Clients.FirstOrDefaultAsync(c => c.Id == client.Id, cancellationToken).GetAwaiter().GetResult();
                storedClient.LastName = "TODO";
                _context.SaveChanges();

                //_context.Database.ExecuteSqlRaw("Delete From Client");

                transuction.Commit();
            }
            catch (Exception)
            {
                transuction.Rollback();
            }

            return _context.Branchs.Include(b => b.Bank);

            return Enumerable.Empty<Branch>();
        }
    }
}
