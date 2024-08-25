using BankingPanel.Domain.ApplicationUserAggregate;
using BankingPanel.Domain.Common.Interfaces;
using Moq;

namespace BankingPanel.Domain.Tests.ApplicationUserAggregate;

public class ApplicationUserTests
{
       [Fact]
        public void Constructor_ShouldInitializeCorrectly()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var email = "john.doe@example.com";
            var passwordHash = "hashedPassword";
            var roles = new List<string> { "Admin", "User" };
             var passwordHasherMock = new Mock<IPasswordHasher>();
           passwordHasherMock.Setup(ph => ph.IsCorrectPassword("myPassword",passwordHash )).Returns(true);
            // Act
            var user = new ApplicationUser(firstName, lastName, email, passwordHash, roles);

            // Assert
            Assert.True(user.Active);
            Assert.Equal(firstName, user.FirstName);
            Assert.Equal(lastName, user.LastName);
            Assert.Equal(email, user.Email);

            Assert.Equal(roles, user.Roles);
        }
}