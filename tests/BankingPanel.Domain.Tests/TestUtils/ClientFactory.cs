using BankingPanel.Domain.ClientAggregate;
using BankingPanel.Domain.Common.ValueObjects;
using BankingPanel.Domain.Tests.TestConsts;

namespace BankingPanel.Domain.Tests.TestUtils;

public static class ClientFactory
{
    public static Client CreateClient( string Email,
    string FirstName,
    string LastName,
    string PersonalId,
    Sex Sex,
    byte[]? Photo,
    PhoneNumber PhoneNumber,
    Address Address)
    {
        return new Client(new CreateClientInput(Email, FirstName, LastName, PersonalId, Sex, Photo, PhoneNumber, Address), Constants.Client.Id);
    }
}