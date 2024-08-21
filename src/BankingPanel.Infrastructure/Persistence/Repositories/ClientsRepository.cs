using BankingPanel.Application.Common.Interfaces;
using BankingPanel.Domain.ApplicationUserAggregate;
using BankingPanel.Domain.ClientAggregate;
using Microsoft.EntityFrameworkCore;

namespace BankingPanel.Infrastructure.Persistence.Repositories;

public class ClientsRepository : IClientsRepository
{
    private readonly BankingPanelDbContext _dbContext;

    public ClientsRepository(BankingPanelDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddClientAsync(Client client)
    {
        await _dbContext.Clients.AddAsync(client); 
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsByPersonalIdAsync(string PersonalId)
    {
      return await _dbContext.Clients.AnyAsync(x=> x.PersonalId == PersonalId);

    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _dbContext.Clients.AnyAsync(x => x.Email.ToLower() == email.Trim().ToLower());

    }

    public async Task<Client?> GetByIdAsync(Guid clientId)
    {
        return await _dbContext.Clients.Include(x=>x.BankAccounts).FirstOrDefaultAsync(x=> x.Id == clientId);
    }

    public async Task<PagedResultDto<Client>> SearchClientsAsync(string searchText = "", string sortBy = "Id", int pageSize = 10, bool sortDescending = false, int pageIndex = 0)
    {
        var query = _dbContext.Clients.Include(x => x.BankAccounts).AsQueryable();


        // Apply filtering
        if (!string.IsNullOrEmpty(searchText))
        {
            query = query.Where(x => x.FirstName.ToLower().Contains(searchText.Trim().ToLower()) || x.LastName.ToLower().Contains(searchText.Trim().ToLower()) || x.PersonalId.ToLower().Contains(searchText.Trim().ToLower()));
        }

        // Apply sorting
        if (!string.IsNullOrEmpty(sortBy))
        {
            query = sortDescending
                ? query.OrderByDescending(e => EF.Property<object>(e, sortBy))
                : query.OrderBy(e => EF.Property<object>(e, sortBy));
        }

        // Get the total count
        var totalCount = await query.CountAsync();

        // Apply paging
        var items = await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();

        return new PagedResultDto<Client>(items, pageIndex, pageSize, totalCount);

    }

    public async Task UpdateAsync(Client client)
    {
        _dbContext.Update(client);
        await _dbContext.SaveChangesAsync();
    }
}
