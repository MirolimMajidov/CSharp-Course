namespace BankManagementSystem.Models
{
    public record RequestOrderCard
    {
        public CardType Type { get; set; }

        public Guid HolderId { get; set; }
    }
}
