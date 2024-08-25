using System.Reflection.Metadata;
using BankingPanel.Domain.Common;
using BankingPanel.Domain.Common.ValueObjects;

namespace BankingPanel.Domain.ClientAggregate
{
    public sealed class Client : AggregateRoot
    {
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PersonalId { get; private set; }
        public byte[] Photo { get; private set; }
        public Sex Sex { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Address Address { get; private set; }
        public Client(CreateClientInput input, Guid? id = null) : base(id ?? Guid.NewGuid())
        {            
            Email = input.Email;
            FirstName = input.FirstName;
            LastName = input.LastName;
            PersonalId = input.PersonalId;
            Photo = input.Photo;
            PhoneNumber = input.PhoneNumber;
            Address = input.Address;
            Sex = input.Sex;
        }        

        private List<BankAccount> _bankAccounts = new List<BankAccount>();

        public IReadOnlyList<BankAccount> BankAccounts => _bankAccounts.AsReadOnly();

        public void AddBankAccount(BankAccount bankAccount)
        {
            _bankAccounts.Add(bankAccount);
        }

        public void RemoveBankAccount(BankAccount bankAccount)
        {
            _bankAccounts.Remove(bankAccount);
        }

        public void UpdateClient(UpdateClientInput input)
        {
            Email = input.Email;
            FirstName = input.FirstName;
            LastName = input.LastName;
            PersonalId = input.PersonalId;
            Photo = input.Photo;
            PhoneNumber = input.PhoneNumber;
            Address = input.Address;
        }


        private Client(){}
    }
}
