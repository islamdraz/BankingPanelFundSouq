using BankingPanel.Application.Clients.Commands.CreateClient;
using BankingPanel.Contracts.Client;
using BankingPanel.Domain.ClientAggregate;
using ErrorOr;
using MapsterMapper;
using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BankingPanel.Api.Controllers;

[Route("client")]
[AllowAnonymous]
public class ClientController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public ClientController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateClient(CreateClientRequest request)
    {
        Sex sx = ParseSex(request.sex);
        var command = _mapper.Map<CreateClientCommand>(request);
        ErrorOr<Client> createClientResult = await _mediator.Send(command);

        return createClientResult.Match(
            result => Ok(_mapper.Map<CreateClientResponse>(result)),
            Problem);
    }

    private Sex ParseSex(string sex)
    {
        if (Enum.TryParse(sex, true, out Sex parsedSex))
        {
            return parsedSex;
        }
        return Sex.Unknown;
    }

    private AccountCurrency ParseCurrency(string currency)
    {
        if (Enum.TryParse(currency, true, out AccountCurrency parsedSex))
        {
            return parsedSex;
        }
        return AccountCurrency.EGP;
    }



}