namespace BankManagementSystem.Models
{
    public class Transaction : BaseEntity
    {
        public Currency Currency { get; set; } = Currency.USD;
        public TransactionType Type { get; set; } = TransactionType.Income;

        public double Amount { get; set; }
        public Client Client { get; set; }
        public Guid ClientId { get; set; }
    }

    public enum Currency
    {
        TJS,
        USD,
        RUB
    }

    public enum TransactionType
    {
        Income,
        Transfer
    }
}
