using BankManagementSystem.Infrastructure;
using BankManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
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
        //[Authorize(Roles = "admin")]
        [Authorize(policy: "AdminOnly")]
        public IEnumerable<Branch> AllBranchs(CancellationToken cancellationToken)
        {
            return _context.Branchs;
        }

        [HttpGet("GetBranchById")]
        [Authorize(Roles = "editor")]
        public Branch Get(Guid guid)
        {
            return _context.Branchs.FirstOrDefault(b => b.Id == guid);
        }
    }
}
