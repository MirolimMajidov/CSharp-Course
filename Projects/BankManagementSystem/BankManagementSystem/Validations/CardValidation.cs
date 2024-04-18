using BankManagementSystem.Models;
using FluentValidation;

namespace BankManagementSystem.Validations;

public class CardValidation : AbstractValidator<RequestOrderCard>
{
    public CardValidation()
    {
        RuleFor(x => x.Type).Must(t => t > CardType.LocalCard).WithMessage("Ordering a local card is not allowed");
        RuleFor(x => x.HolderId).Must(t => t != Guid.Empty).WithMessage("HolderId must have value");
    }
}
