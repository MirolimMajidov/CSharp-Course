using AutoMapper;
using BankManagementSystem.Extensions;
using BankManagementSystem.Infrastructure;
using BankManagementSystem.Models;
using BankManagementSystem.Services;
using BankManagementSystem.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly ILogger<CardController> _logger;
        private readonly ISQLRepository<Card> _repository;
        private readonly IMapper _mapper;

        public CardController(ILogger<CardController> logger, ISQLRepository<Card> repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("CardsByHolderId")]
        public ActionResult<IEnumerable<ResponseCard>> CardsByHolderId(RequestCardsByHolderId holder)
        {
            var cards = _repository.GetAll().Where(c => c.HolderId == holder.HolderId);

            return _mapper.Map<List<ResponseCard>>(cards);
        }

        [HttpPost("Order")]
        [Authorize]
        public ActionResult<string> OrderCard(RequestOrderCard requestOrder)
        {
            var validator = new CardValidation();
            var result = validator.Validate(requestOrder);

            if (!result.IsValid)
            {
                var message = string.Join("; ", result.Errors);
                return BadRequest(message);
            }

            var workerId = User.GetCurrectUserId();
            var card = _mapper.Map<Card>(requestOrder);
            card.Balance = 5;
            card.IssuerId = workerId;

            var createdCard = _repository.TryCreate(card, out string _message);
            if (createdCard is null)
                return BadRequest(_message);

            return Created();
        }
    }
}
