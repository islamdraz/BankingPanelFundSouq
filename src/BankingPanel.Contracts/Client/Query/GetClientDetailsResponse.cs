namespace BankingPanel.Application.Clients.Commands.CreateClient;

public record GetClientDetailsResponse (  Guid Id,
    string Email,
    string FirstName,
    string LastName,
    string PersonalId,
    string sex,
    byte[] Photo,
    string Country ,
    string City ,
    string Street,
    string ZibCode,
    string CountryCode,
    string Number,
    List<BankAccountDetailsResponse> BankAccounts );

public record BankAccountDetailsResponse ( string AccountNumber, string AccountCurrency );
