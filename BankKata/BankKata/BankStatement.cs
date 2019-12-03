using System.Collections.Generic;

namespace BankKata
{
    public class BankStatement
    {
        private const string Header = "date       || credit   || debit    || balance";
        private readonly List<Transaction> _transactions;

        public BankStatement(List<Transaction> transactions)
        {
            _transactions = transactions;
        }

        public bool ContainsTransaction(Transaction transaction)
        {
            return _transactions.Contains(transaction);
        }

        public override string ToString()
        {
            var statement = new List<string>();
            var balance = 0m;

            foreach (var transaction in _transactions)
            {
                balance = transaction.CurrentBalance(balance);
                statement.Add(transaction.Format(balance));
            }

            statement.Add(Header);
            statement.Reverse();

            return string.Join('\n', statement);
        }
    }
}