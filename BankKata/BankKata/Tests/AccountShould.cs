using System;
using NSubstitute;
using Xunit;

namespace BankKata.Tests
{
    public class AccountShould
    {
        private readonly PrinterShould _printerShould = new PrinterShould();

        [Fact]
        public void GenerateACreditTransaction()
        {
            var transaction = new Transaction(1, new DateTime(2012,01, 12), TransactionType.Credit);
            var transactionRepository = Substitute.For<ITransactionRepository>();
            var timeService = Substitute.For<ITime>();
            timeService.GetTime().Returns(new DateTime(2012, 01, 12));
            var account = new Account(transactionRepository, Substitute.For<IPrinter>(), timeService);

            account.Deposit(1);

            transactionRepository.Received().Save(transaction);
        }

        [Fact]
        public void GenerateADebitTransaction()
        {
            var transaction = new Transaction(1, new DateTime(2012, 01, 12), TransactionType.Debit);
            var transactionRepository = Substitute.For<ITransactionRepository>();
            var timeService = Substitute.For<ITime>();
            timeService.GetTime().Returns(new DateTime(2012, 01, 12));
            var account = new Account(transactionRepository, Substitute.For<IPrinter>(), timeService);

            account.Withdraw(1);

            transactionRepository.Received().Save(transaction);
        }
    }
}