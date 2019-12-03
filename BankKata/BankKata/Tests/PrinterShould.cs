using System;
using System.Collections.Generic;
using NSubstitute;
using Xunit;

namespace BankKata.Tests
{
    public class PrinterShould
    {
        private string header = "date       || credit   || debit    || balance";

        [Fact]
        public void PrintEmptyBankStatement()
        {
            var console = Substitute.For<IConsole>();
            var printer = new Printer(console);
            var emptyTransactions = new List<Transaction>();

            printer.Print(new BankStatement(emptyTransactions));

            console.Received().Print(header);
        }

        [Fact]
        public void PrintStatementWithOneCreditTransaction()
        {
            var console = Substitute.For<IConsole>();
            var printer = new Printer(console);
            var transactions = new List<Transaction> { new Transaction(500, new DateTime(2012, 01, 13), TransactionType.Credit) };

            printer.Print(new BankStatement(transactions));
            
            var statement = "\n13/01/2012 || 500.00 ||          || 500.00";

            console.Received().Print(header + statement);
        }

        [Fact]
        public void PrintStatementWithOneDebitTransaction()
        {
            var console = Substitute.For<IConsole>();
            var printer = new Printer(console);
            var transactions = new List<Transaction>
            {
                new Transaction(500, new DateTime(2012, 01, 13), TransactionType.Credit),
                new Transaction(500, new DateTime(2012, 01, 13), TransactionType.Debit)
            };

            printer.Print(new BankStatement(transactions));

            var statementDebit = "\n13/01/2012 ||          || 500.00 || 0.00";
            var statementCredit = "\n13/01/2012 || 500.00 ||          || 500.00";

            console.Received().Print(header + statementDebit + statementCredit);
        }
    }
}