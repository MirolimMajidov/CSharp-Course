// Declaration of delegate
using System;

delegate void ActionCalculator(int a, int b);
delegate int FuncCalculator(int a, int b);

class Program
{
    static void Main()
    {
        //WorkWithStandardEvent();
        //WorkWithCustomEvent();
        ActionCalculator voidCalculator = Addition;
        Action<int, int> voidCalculatorWithAction = Addition;

        FuncCalculator nonVoidCalculator = FuncAddition;
        Func<int, int, int> nonVoidCalculatorWithFunc = FuncAddition;

        //Executing method
        voidCalculator(10, 5);//Result: 15
        nonVoidCalculator(10, 5);//Result: 15

        //Recalling delegate
        nonVoidCalculator = (a, b) => a + b;
        voidCalculator = Subtraction;

        //Methods for operations

        int FuncAddition(int a, int b) => a + b;
        void Addition(int a, int b) => Console.Write(a + b);

        void Subtraction(int a, int b) => Console.WriteLine(a - b);
    }


    // Declaration of event
    public static event EventHandler MyEvent;

    static void WorkWithStandardEvent()
    {
        // Subscribing to the event
        MyEvent += (sender, e) => Console.WriteLine("Event triggered!");

        // Raising the event
        MyEvent?.Invoke(null, EventArgs.Empty);
    }

    static void WorkWithCustomEvent()
    {
        var user = new User();
        user.Balance = 10;
        user.TransactionCompleted += (sender, e) => TransactionNotify(sender, e);

        user.Transaction(15);
        user.Transaction(-20);
    }

    static void TransactionNotify(object sender, TransactionCompletedEventArgs eventArgs)
    {

    }
}

public class User
{
    public double Balance { get; set; }
    public event EventHandler<TransactionCompletedEventArgs> TransactionCompleted;

    public void Transaction(int moneyToTransaction)
    {
        Balance += moneyToTransaction;

        // Raise the event with custom data
        //TransactionCompleted?.Invoke(this, EventArgs.Empty);
        TransactionCompleted?.Invoke(this, new TransactionCompletedEventArgs(moneyToTransaction, Balance));
    }
}

public class TransactionCompletedEventArgs : EventArgs
{
    public double TransferedMoney { get; private set; }
    public double AccountBalance { get; private set; }
    public TransactionCompletedEventArgs(double transferedMoney, double accountBalance)
    {
        TransferedMoney = transferedMoney;
        AccountBalance = accountBalance;
    }
}

