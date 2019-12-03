namespace BankKata
{
    public interface ITransactionRepository
    {
        void Save(Transaction transaction);

        BankStatement GetBankStatement();
    }
}