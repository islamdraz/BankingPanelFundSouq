using BankingPanel.Domain.ClientAggregate;
using BankingPanel.Domain.Common.ValueObjects;
using ErrorOr;
using MediatR;

namespace BankingPanel.Application.Clients.Commands.CreateClient;

public record CreateClientCommand (  string Email,
    string FirstName,
    string LastName,
    string PersonalId,
    Sex Sex,
    PhoneNumber PhoneNumber,
    Address Address,
    List<BankAccountCommand> BankAccounts,
    byte[]? Photo = null) :  IRequest<ErrorOr<Client>>;


public record BankAccountCommand(string AccountNumber, AccountCurrency AccountCurrency);
    