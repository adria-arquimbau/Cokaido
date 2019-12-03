using System;
using NSubstitute;
using Xunit;

namespace BankKata.Tests
{
    public class BankAppShould
    {
        [Fact]
        public void PrintBankStatement()
        {
            // Arrange
            var expectedBankStatement = 
            "date       || credit   || debit    || balance" +
            "\n14/01/2012 ||          || 500.00 || 2,500.00" +
            "\n13/01/2012 || 2,000.00 ||          || 3,000.00" +
            "\n10/01/2012 || 1,000.00 ||          || 1,000.00";

            var console = Substitute.For<IConsole>();
            var transactionRepository = new TransactionRepository();
            var printer = new Printer(console);
            var timeService = Substitute.For<ITime>();
            timeService.GetTime().Returns(new DateTime(2012, 01, 10), new DateTime(2012, 01, 13),
                new DateTime(2012, 01, 14));

            var account = new Account(transactionRepository, printer, timeService);

            account.Deposit(1000);
            account.Deposit(2000);
            account.Withdraw(500);

            //Act
            account.PrintStatement();

            //Assert
            console.Received().Print(expectedBankStatement);
        }
    }
}
