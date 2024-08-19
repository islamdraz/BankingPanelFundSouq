using BankingPanel.Domain.ApplicationUserAggregate;

namespace BankingPanel.Application.Common.Interfaces;

public interface IUsersRepository
{
    Task AddUserAsync(ApplicationUser user);
    Task<bool> ExistsByEmailAsync(string email);
    Task<ApplicationUser?> GetByEmailAsync(string email);
    Task<ApplicationUser?> GetByIdAsync(Guid userId);
    Task UpdateAsync(ApplicationUser user);
}