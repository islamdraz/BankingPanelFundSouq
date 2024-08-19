using BankingPanel.Domain.Common;

namespace BankingPanel.Domain.ClientAggregate
{
    public class BankAccount : Entity
    {
        public Guid ClientId { get; private set; }
        public string AccountNumber { get; private set; }
        public AccountCurrency AccountCurrency { get; private set; }

        public BankAccount(string accountNumber, AccountCurrency accountCurrency , Guid? id = null) : base(id ?? Guid.NewGuid())
        {
            AccountNumber = accountNumber;
            AccountCurrency = accountCurrency;
        }

        public void UpdateAccount(string accountNumber, AccountCurrency accountCurrency)
        {
            AccountNumber = accountNumber;
            AccountCurrency = accountCurrency;
        }
        private BankAccount() { }
    }
}
