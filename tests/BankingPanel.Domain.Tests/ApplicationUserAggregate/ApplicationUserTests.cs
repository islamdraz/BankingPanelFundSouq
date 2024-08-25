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
            // Act
            var user = new ApplicationUser(firstName, lastName, email, passwordHash, roles);

            // Assert
            Assert.True(user.Active);
            Assert.Equal(firstName, user.FirstName);
            Assert.Equal(lastName, user.LastName);
            Assert.Equal(email, user.Email);

            Assert.Equal(roles, user.Roles);
        }


        [Fact]
        public void IsCorrectPasswordHash_ShouldReturnTrue_WhenPasswordIsCorrect()
        {
            // Arrange
            var passwordHasherMock = new Mock<IPasswordHasher>();
            var correctPassword = "correctPassword";
            var correctHash = "correctHash";

            passwordHasherMock.Setup(ph => ph.IsCorrectPassword(correctPassword, correctHash))
                              .Returns(true);

            var user = new ApplicationUser("John", "Doe", "john.doe@example.com", correctHash, new List<string>());

            // Act
            var result = user.IsCorrectPasswordHash(correctPassword, passwordHasherMock.Object);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsCorrectPasswordHash_ShouldReturnFalse_WhenPasswordIsIncorrect()
        {
            // Arrange
            var passwordHasherMock = new Mock<IPasswordHasher>();
            var correctPassword = "correctPassword";
            var incorrectPassword = "wrongPassword";
            var correctHash = "correctHash";

            passwordHasherMock.Setup(ph => ph.IsCorrectPassword(incorrectPassword, correctHash))
                              .Returns(false);

            var user = new ApplicationUser("John", "Doe", "john.doe@example.com", correctHash, new List<string>());

            // Act
            var result = user.IsCorrectPasswordHash(incorrectPassword, passwordHasherMock.Object);

            // Assert
            Assert.False(result);
        }


        [Fact]
        public void ChangePassword_ShouldUpdatePasswordHash()
        {
            // Arrange
            var initialPasswordHash = "initialHash";
            var newPasswordHash = "newHash";
            var user = new ApplicationUser("John", "Doe", "john.doe@example.com", initialPasswordHash, new List<string>());

            // Act
            user.ChangePassword(newPasswordHash);
            var passwordHasherMock = new Mock<IPasswordHasher>();
             passwordHasherMock.Setup(ph => ph.IsCorrectPassword(newPasswordHash, newPasswordHash))
                              .Returns(true);
            // Act

            // Assert
            Assert.True(user.IsCorrectPasswordHash(newPasswordHash, passwordHasherMock.Object));
        }

        [Fact]
        public void Deactivate_ShouldSetActiveToFalse()
        {
            // Arrange
            var user = new ApplicationUser("John", "Doe", "john.doe@example.com", "hashedPassword", new List<string>());

            // Act
            user.Deactivate();

            // Assert
            Assert.False(user.Active);
        }

        [Fact]
        public void Reactivate_ShouldSetActiveToTrue()
        {
            // Arrange
            var user = new ApplicationUser("John", "Doe", "john.doe@example.com", "hashedPassword", new List<string>());
            user.Deactivate();

            // Act
            user.Reactivate();

            // Assert
            Assert.True(user.Active);
        }
}