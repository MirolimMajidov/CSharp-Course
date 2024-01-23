namespace BankManagementSystem.Models;

public class Worker : Person
{
    public string Role { get; set; }

    public override void DoWork()
    {
        base.DoWork();

        Console.WriteLine("I am done " + GetType().Name + " from overwriten method");
    }
}
