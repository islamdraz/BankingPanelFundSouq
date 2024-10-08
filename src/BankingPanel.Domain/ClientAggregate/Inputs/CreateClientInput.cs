using BankingPanel.Domain.ClientAggregate;
using System.Reflection.Metadata;

namespace BankingPanel.Domain.Common.ValueObjects;

public record CreateClientInput(
    string Email,
    string FirstName,
    string LastName,
    string PersonalId,
    Sex Sex,
    byte[]? Photo,
    PhoneNumber PhoneNumber,
    Address Address
);