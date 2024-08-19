using BankingPanel.Application.Common.Interfaces;
using BankingPanel.Domain.ApplicationUserAggregate;
using Microsoft.EntityFrameworkCore;


namespace BankingPanel.Infrastructure.Persistence.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly BankingPanelDbContext _dbContext;

    public UsersRepository(BankingPanelDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddUserAsync(ApplicationUser user)
    {
        await _dbContext.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _dbContext.ApplicationUsers.AnyAsync(user => user.Email == email);
    }

    public async Task<ApplicationUser?> GetByEmailAsync(string email)
    {
        return await _dbContext.ApplicationUsers.FirstOrDefaultAsync(user => user.Email == email);
    }

    public async Task<ApplicationUser?> GetByIdAsync(Guid userId)
    {
        return await _dbContext.ApplicationUsers.FirstOrDefaultAsync(user => user.Id == userId);
    }

    public async Task UpdateAsync(ApplicationUser user)
    {
        _dbContext.Update(user);
        await _dbContext.SaveChangesAsync();
    }
}
