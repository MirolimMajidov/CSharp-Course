namespace BankManagementSystem.Models
{
    public class Client : Person
    {
        public ClientStatus State { get; set; }
    }

    public enum ClientStatus
    {
        Orginization,
        Persion
    }
}
