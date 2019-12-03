using System.Collections.Generic;

namespace BankKata
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly List<Transaction> _transactions;

        public TransactionRepository()
        {
            _transactions = new List<Transaction>();
        }

        public void Save(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public BankStatement GetBankStatement()
        {
            return new BankStatement(_transactions);
        }
    }   
}