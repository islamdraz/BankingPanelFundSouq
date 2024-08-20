using BankingPanel.Domain.ClientAggregate;

namespace BankingPanel.Application.Common.Interfaces;

public interface IClientsRepository
{
    Task AddClientAsync(Client client);
    Task<bool> ExistsByPersonalIdAsync(string PersonalId);
    Task<Client?> GetByIdAsync(Guid clientId);
    Task UpdateAsync(Client client);
}