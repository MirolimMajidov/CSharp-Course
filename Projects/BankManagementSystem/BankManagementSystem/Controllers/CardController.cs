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

        public CardController(ILogger<CardController> logger, BankContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("CardsByHolderId")]
        public IEnumerable<ResponseCard> CardsByHolderId(RequestCardsByHolderId holder)
        {
            var cards = _context.Cards.Where(c => c.HolderId == holder.HolderId);

            var result = new List<ResponseCard>();
            foreach (var card in cards)
            {
                result.Add(new ResponseCard
                {
                    Id = card.Id,
                    Balance = card.Balance,
                    IssuerId = card.IssuerId,
                    Status = card.Status,
                    Type = card.Type
                });
            }

            return result;
        }

        [HttpPost("Order")]
        [Authorize]
        public string OrderCard(RequestOrderCard requestOrder)
        {
            var workerId = User.GetCurrectUserId();
            var card = new Card
            {
                HolderId = requestOrder.HolderId,
                Type = requestOrder.Type,
                Status = CardStatus.JustOrdered,
                Balance = 5,
                IssuerId = workerId
            };
            _context.Add(card);
            _context.SaveChanges();

            return "Card is ordered";
        }
    }
}
