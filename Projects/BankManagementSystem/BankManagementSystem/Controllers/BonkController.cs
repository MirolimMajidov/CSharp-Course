using BankManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BonkController : ControllerBase
    {
        private readonly ILogger<BonkController> _logger;

        public BonkController(ILogger<BonkController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBonk")]
        public Bonk Get()
        {
            var bonk = new Bonk();
            bonk.Name = "Eskhata";
            bonk.Address = "Guliston";

            var branch1 = new Branch();
            branch1.Address = "Station";

            var branch2 = new Branch();
            branch2.Address = "Guliston, Glavnoy";

            bonk.Branchs.Add(branch1);
            bonk.Branchs.Add(branch2);

            return bonk;
        }
    }
}
