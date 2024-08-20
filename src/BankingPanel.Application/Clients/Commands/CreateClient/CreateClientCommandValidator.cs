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
        RuleFor(x => x.sex).IsInEnum();        
        RuleFor(x => x.Address).SetValidator(new AddressValidator());
        RuleFor(x => x.PhoneNumber).SetValidator(new PhoneNumberValidator());
        RuleFor(x => x.BankAccounts).Must(x=> x.Count > 0);
    }
}

internal class PhoneNumberValidator : AbstractValidator<PhoneNumber>
{
    public PhoneNumberValidator()
    {
        RuleFor(x => x.CountryCode).NotEmpty();
        RuleFor(x => x.Number).NotEmpty();
    }
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