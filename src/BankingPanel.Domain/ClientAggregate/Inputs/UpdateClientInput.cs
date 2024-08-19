using System.Reflection.Metadata;

namespace BankingPanel.Domain.Common.ValueObjects;

public record UpdateClientInput(
    string Email,
    string FirstName,
    string LastName,
    string PersonalId,
    byte[] Photo,
    PhoneNumber PhoneNumber,
    Address Address
);