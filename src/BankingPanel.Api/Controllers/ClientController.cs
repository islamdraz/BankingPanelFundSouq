using BankingPanel.Application.Clients.Commands.CreateClient;
using BankingPanel.Application.Clients.Queries;
using BankingPanel.Contracts.Client;
using BankingPanel.Contracts.Client.Query;
using BankingPanel.Contracts.Common;
using BankingPanel.Domain.ClientAggregate;
using ErrorOr;
using MapsterMapper;
using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BankingPanel.Api.Controllers;

[Route("client")]
[Authorize(Roles = "admin")]
public class ClientController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public ClientController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetClients([FromQuery] SearchClientRequest request)
    {
        var query = _mapper.Map<SearchClientQuery>(request);
        ErrorOr<PagedResultDto<Client>> searchResult = await _mediator.Send(query);

        // return the search result or excecute the problem method in base ApiController
        return searchResult.Match(
            result => Ok(_mapper.Map<PagedResponse<GetClientDetailsResponse>>(result)),
            Problem);
    }

    [HttpPost]
    public async Task<IActionResult> CreateClient(CreateClientRequest request)
    {
        var command = _mapper.Map<CreateClientCommand>(request);
        ErrorOr<Client> createClientResult = await _mediator.Send(command);

        // return the Created Client or excecute the problem method in base ApiController
        return createClientResult.Match(
            result => Ok(_mapper.Map<CreateClientResponse>(result)),
            Problem);
    }

}