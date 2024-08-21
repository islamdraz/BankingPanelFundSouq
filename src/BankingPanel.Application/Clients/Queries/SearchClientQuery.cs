

using BankingPanel.Application.Clients.common;
using BankingPanel.Domain.ClientAggregate;
using ErrorOr;
using MediatR;

namespace BankingPanel.Application.Clients.Queries;

public record SearchClientQuery : BaseSearchQuery , IRequest<ErrorOr<PagedResultDto<Client>>>;
