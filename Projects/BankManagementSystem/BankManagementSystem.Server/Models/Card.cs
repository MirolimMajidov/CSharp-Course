namespace BankManagementSystem.Models
{
    public class Card : BaseEntity
    {
        public CardType Type { get; set; }

        public Guid HolderId { get; set; }

        public Guid IssuerId { get; set; }

        public CardStatus Status { get; set; } = CardStatus.JustOrdered;

        public double Balance { get; set; }
    }
}
