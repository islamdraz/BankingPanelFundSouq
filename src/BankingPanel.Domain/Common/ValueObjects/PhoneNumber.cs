
namespace BankingPanel.Domain.Common.ValueObjects;

public class PhoneNumber : ValueObject
{
    public string CountryCode { get; }
    public string Number { get; }

    public PhoneNumber(string countryCode, string number)
    {
        CountryCode = countryCode;
        Number = number;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return CountryCode;
        yield return Number;
    }
}