namespace BankManagementSystem.Models
{
    public class Client : Person
    {
        public ClientStatus State { get; set; }

        //public List<Transaction> Transactions { get; set; }
    }

    public enum ClientStatus
    {
        Orginization,
        Persion
    }
}
