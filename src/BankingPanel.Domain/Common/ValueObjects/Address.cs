namespace BankingPanel.Domain.Common.ValueObjects;

public class Address : ValueObject
{
    public string Country { get; }
    public string City { get; }
    public string Street { get; }
    public string ZibCode { get; }

    public Address(string country, string city, string street, string zibCode)
    {
        Country = country;
        City = city;
        Street = street;
        ZibCode = zibCode;
    }   

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Country;
        yield return City;
        yield return Street;
        yield return ZibCode;
    }
}