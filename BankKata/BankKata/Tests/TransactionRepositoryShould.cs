using System;
using Xunit;

namespace BankKata.Tests
{
    public class TransactionRepositoryShould
    {
        private Transaction _transaction;

        [Fact]
        public void SaveOneDeposit()
        {
            var transactionRepository = new TransactionRepository();
            _transaction = new Transaction(1, new DateTime(2012, 01, 12), TransactionType.Credit);
            transactionRepository.Save(_transaction);

            var transactions = transactionRepository.GetBankStatement();

            Assert.True(transactions.ContainsTransaction(_transaction));
        }
    }
}