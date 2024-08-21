using BankingPanel.Domain.ClientAggregate;

namespace BankingPanel.Application.Common.Interfaces;

public interface IClientsRepository
{
    Task AddClientAsync(Client client);
    Task<bool> ExistsByPersonalIdAsync(string PersonalId);
    Task<bool> ExistsByEmailAsync(string email);
    Task<Client?> GetByIdAsync(Guid clientId);
    Task UpdateAsync(Client client);

    Task<PagedResultDto<Client>> SearchClientsAsync(string searchText = "", string sortBy = "Id", int pageSize = 10, bool sortDescending = false, int pageNumber = 0);
}