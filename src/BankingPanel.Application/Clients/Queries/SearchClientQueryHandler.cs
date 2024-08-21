using ErrorOr;
using MediatR;
using BankingPanel.Domain.ClientAggregate;
using BankingPanel.Application.Clients.Queries;
using BankingPanel.Application.Common.Interfaces;


namespace BankingPanel.Contracts.Clients.Query;

public class SearchClientQueryHandler : IRequestHandler<SearchClientQuery, ErrorOr<PagedResultDto<Client>>>
{

    private readonly IClientsRepository _clientsRepository;

   

    public SearchClientQueryHandler(IClientsRepository clientsRepository)
    {
        _clientsRepository = clientsRepository;
    }
    public async Task<ErrorOr<PagedResultDto<Client>>> Handle(SearchClientQuery request, CancellationToken cancellationToken)
    {
        return await _clientsRepository.SearchClientsAsync(request.SearchText, request.SortBy, request.PageSize, request.SortDescending, request.PageNumber);
    }
}