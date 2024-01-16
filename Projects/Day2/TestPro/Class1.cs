namespace TestPro
{
    class Program
    {
        static void Main()
        {
            var user = new User();
            user.Balance = 10;
            user.TransactionCompleted += (sender, e) => TransactionNotify(sender, e);


            user.Transaction(15);
            user.Transaction(-20);
        }

        static void TransactionNotify(object sender, EventArgs eventArgs)
        {

        }
    }
    public class User
    {
        public double Balance { get; set; }
        public event EventHandler<EventArgs> TransactionCompleted;

        public void Transaction(int moneyToTransaction)
        {
            Balance += moneyToTransaction;

            // Raise the event with custom data
            TransactionCompleted?.Invoke(this, EventArgs.Empty);
            //TransactionCompleted?.Invoke(this, new TransactionCompletedEventArgs(moneyToTransaction, Balance));
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
}
