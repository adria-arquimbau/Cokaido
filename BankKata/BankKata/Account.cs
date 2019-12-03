namespace BankKata
{
    public class Account
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IPrinter _printer;
        private readonly ITime _time;

        public Account(ITransactionRepository transactionRepository, IPrinter printer, ITime time)
        {
            _transactionRepository = transactionRepository;
            _printer = printer;
            _time = time;
        }

        public void PrintStatement()
        {
            _printer.Print(_transactionRepository.GetBankStatement());
        }

        public void Deposit(int amount)
        {
            _transactionRepository.Save(new Transaction(amount, _time.GetTime(), TransactionType.Credit));
        }

        public void Withdraw(int amount)
        {
            _transactionRepository.Save(new Transaction(amount, _time.GetTime(), TransactionType.Debit));
        }
    }
}