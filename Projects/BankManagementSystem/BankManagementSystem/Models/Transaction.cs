namespace BankManagementSystem.Models
{
    public class Transaction : BaseEntity
    {
        public Currency Currency { get; set; }
        public TransactionType Type { get; set; }

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
