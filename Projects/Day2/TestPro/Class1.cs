namespace TestPro
{
    public class User
    {
        public double Balance { get; set; }
        public event EventHandler<TransactionCompletedEventArgs> TransactionCompleted;

        public void Transaction(int moneyToTransaction)
        {
            Balance -= moneyToTransaction;

            // Raise the event with custom data
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
}
