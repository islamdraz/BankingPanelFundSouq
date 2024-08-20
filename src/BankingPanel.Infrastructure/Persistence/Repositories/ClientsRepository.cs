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
      var xx =  await _dbContext.Clients.FirstOrDefaultAsync(x=> x.PersonalId == PersonalId);

        return xx != null;
    }

    public async Task<Client?> GetByIdAsync(Guid clientId)
    {
        return await _dbContext.Clients.FindAsync( clientId);
    }

    public async Task UpdateAsync(Client client)
    {
        _dbContext.Update(client);
        await _dbContext.SaveChangesAsync();
    }
}
