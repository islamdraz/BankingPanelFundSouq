using BankingPanel.Application.Clients.Commands.CreateClient;
using BankingPanel.Domain.Common.ValueObjects;
using FluentValidation;

namespace BankingPanel.Application.Authentication.Register;
public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
{

    public CreateClientCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(60);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(60);
        RuleFor(x => x.PersonalId).NotEmpty().Length(11);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Sex).IsInEnum();        
        RuleFor(x => x.Address).SetValidator(new AddressValidator());
        RuleFor(x => x.PhoneNumber).SetValidator(new PhoneNumberValidator());
        RuleFor(x => x.BankAccounts).Must(x=> x.Count > 0);
    }
}

internal class PhoneNumberValidator : AbstractValidator<PhoneNumber>
{
    private static readonly List<string> ValidCountryCodes = new List<string>
    {
        "+2", "002", "+699", "699"
    };
    public PhoneNumberValidator()
    {
        RuleFor(x => x.CountryCode).NotEmpty().Must(BeAValidCountryCode).WithMessage("Country code is not valide");
        RuleFor(x => x.Number).NotEmpty();
    }

    private bool BeAValidCountryCode(string countryCode) => ValidCountryCodes.Contains(countryCode);
    

}

internal class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(x => x.Country).NotEmpty();
        RuleFor(x => x.City).NotEmpty();
        RuleFor(x => x.Street).NotEmpty();
    }
}