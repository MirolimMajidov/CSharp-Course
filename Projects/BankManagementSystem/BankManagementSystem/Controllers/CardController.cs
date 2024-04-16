using AutoMapper;
using BankManagementSystem.Extensions;
using BankManagementSystem.Infrastructure;
using BankManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly ILogger<CardController> _logger;
        private readonly BankContext _context;
        private readonly IMapper _mapper;

        public CardController(ILogger<CardController> logger, BankContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("CardsByHolderId")]
        public IEnumerable<ResponseCard> CardsByHolderId(RequestCardsByHolderId holder)
        {
            var cards = _context.Cards.Where(c => c.HolderId == holder.HolderId);

            return _mapper.Map<List<ResponseCard>>(cards);
        }

        [HttpPost("Order")]
        [Authorize]
        public string OrderCard(RequestOrderCard requestOrder)
        {
            var workerId = User.GetCurrectUserId();
            var card = _mapper.Map<Card>(requestOrder);
            card.Balance = 5;
            card.IssuerId = workerId;

            _context.Add(card);
            _context.SaveChanges();

            return "Card is ordered";
        }
    }
}
