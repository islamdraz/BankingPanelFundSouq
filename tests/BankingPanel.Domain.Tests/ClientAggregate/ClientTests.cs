using BankingPanel.Domain.ClientAggregate;
using BankingPanel.Domain.Common.ValueObjects;
using BankingPanel.Domain.Tests.TestUtils;
using NuGet.Frameworks;

namespace BankingPanel.Domain.Tests;

public class ClientTests
{

     [Fact]
        public void Constructor_ShouldInitializeClientCorrectly()
        {
           

            // Act
            var client = ClientFactory.CreateClient("test@example.com", "John", "Doe", "1234567890", Sex.Male, new byte[] { 0x01, 0x02 }, new PhoneNumber("123", "4567890"), new Address("Country", "City", "Street", "12345"));

            // Assert
            Assert.Equal("test@example.com", client.Email);
            Assert.Equal("John", client.FirstName);
            Assert.Equal("Doe", client.LastName);
            Assert.Equal("1234567890", client.PersonalId);
            Assert.Equal(new byte[] { 0x01, 0x02 }, client.Photo);
            Assert.Equal(Sex.Male, client.Sex);
            Assert.Equal(new PhoneNumber("123", "4567890"), client.PhoneNumber);
            Assert.Equal(new Address("Country", "City", "Street", "12345"), client.Address);
            Assert.NotEqual(client.Id, Guid.Empty);
            Assert.Empty(client.BankAccounts);
        }
        
         [Fact]
        public void AddBankAccount_ShouldAddBankAccountToClient()
        {
            // Arrange
            var client = ClientFactory.CreateClient("test@example.com", "John", "Doe", "1234567890", Sex.Male, new byte[] { 0x01, 0x02 }, new PhoneNumber("123", "4567890"), new Address("Country", "City", "Street", "12345"));

            var bankAccount = new BankAccount("123456", AccountCurrency.EGP);

            // Act
            client.AddBankAccount(bankAccount);

            // Assert
            Assert.Single(client.BankAccounts);
            Assert.Contains(bankAccount, client.BankAccounts);
        }
        
        [Fact]
        public void RemoveBankAccount_ShouldRemoveBankAccountFromClient()
        {
            // Arrange
             // Act
            var client = ClientFactory.CreateClient("test@example.com", "John", "Doe", "1234567890", Sex.Male, new byte[] { 0x01, 0x02 }, new PhoneNumber("123", "4567890"), new Address("Country", "City", "Street", "12345"));

            var bankAccount = new BankAccount("123456", AccountCurrency.EGP);
            client.AddBankAccount(bankAccount);

            // Act
            client.RemoveBankAccount(bankAccount);

            // Assert
            Assert.Empty(client.BankAccounts);
        }
}