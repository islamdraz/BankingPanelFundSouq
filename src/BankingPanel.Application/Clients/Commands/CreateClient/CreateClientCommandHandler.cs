using BankingPanel.Application.Clients.Commands.Common;
using BankingPanel.Application.Common.Interfaces;
using BankingPanel.Domain.ClientAggregate;
using BankingPanel.Domain.Common.ValueObjects;
using ErrorOr;
using MediatR;

namespace BankingPanel.Application.Clients.Commands.CreateClient;
public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, ErrorOr<Client>>
{
    private readonly IClientsRepository _clientRepository;
    public CreateClientCommandHandler(IClientsRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }
    public async Task<ErrorOr<Client>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        if( await _clientRepository.ExistsByPersonalIdAsync(request.PersonalId))
        {
            return ClientErrors.ClientPersonalIdIsDuplicated;
        }        

        var clientAddInput = new CreateClientInput(request.Email, request.FirstName, request.LastName, request.PersonalId, request.Photo, request.PhoneNumber, request.Address);
        
        var client = new Client(clientAddInput);

        await _clientRepository.AddClientAsync(client);

        return client;

    }
}