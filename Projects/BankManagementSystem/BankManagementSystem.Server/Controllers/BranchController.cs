using BankManagementSystem.Infrastructure;
using BankManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class BranchController : ControllerBase
    {
        private readonly ILogger<BranchController> _logger;
        private readonly BankContext _context;

        public BranchController(ILogger<BranchController> logger, BankContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("AllBranchs")]
        //[Authorize(policy: "AdminOnly")]
        public ActionResult<IEnumerable<Branch>> AllBranchs(CancellationToken cancellationToken)
        {
            return Ok(_context.Branchs);
        }

        [HttpGet("GetBranchById")]
        [Authorize(Roles = "editor")]
        public ActionResult<Branch> Get(Guid guid)
        {
            var item = _context.Branchs.FirstOrDefault(b => b.Id == guid);
            if (item is null)
                return NotFound();

            return Ok(item);
        }
    }
}
