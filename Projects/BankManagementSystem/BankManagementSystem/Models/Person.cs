namespace BankManagementSystem.Models
{
    public abstract class Person: BaseEntity, ICanDoWork
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public DateTimeOffset Birthday { get; set; }

        public virtual void DoWork()
        {
            Console.WriteLine("I am done " + GetType().Name);
        }
    }
}
