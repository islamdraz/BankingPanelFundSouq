namespace BankingPanel.Contracts.Client;


public record CreateClientRequest (  string Email,
    string FirstName,
    string LastName,
    string PersonalId,
    string sex,
    string Country ,
    string City ,
    string Street,
    string ZibCode,
    string CountryCode,
    string Number,
    List<BankAccountRequest> BankAccounts ,
    byte[]? Photo = null);
    
public record  BankAccountRequest ( string AccountNumber, string AccountCurrency );

