namespace BankKata
{
    public class Printer : IPrinter
    {
        private readonly IConsole _console;

        public Printer(IConsole console)
        {
            _console = console;
        }

        public void Print(BankStatement bankStatement)
        {
            _console.Print(bankStatement.ToString());
        }
    }
}