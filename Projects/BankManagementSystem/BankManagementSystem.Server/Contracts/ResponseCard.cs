namespace BankManagementSystem.Models
{
    public record ResponseCard
    {
        public Guid Id { get; set; }

        public CardType Type { get; set; }

        public Guid IssuerId { get; set; }

        public CardStatus Status { get; set; } = CardStatus.JustOrdered;

        public double TotalBalance { get; set; }
    }
}
