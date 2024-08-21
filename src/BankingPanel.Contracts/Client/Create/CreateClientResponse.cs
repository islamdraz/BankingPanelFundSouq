namespace BankingPanel.Contracts.Client;


public record CreateClientResponse ( Guid Id,
    string Email,
    string FirstName,
    string LastName,
    string PersonalId,
    string Sex,
    byte[] Photo,
    string Country ,
    string City ,
    string Street,
    string ZibCode,
    string CountryCode,
    string Number,
    List<BankAccountResponse> BankAccounts );

    public record  BankAccountResponse ( string AccountNumber, string AccountCurrency );

