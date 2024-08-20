
using BankingPanel.Application.Authentication.Common;
using BankingPanel.Application.Authentication.Login;
using BankingPanel.Application.Authentication.Register;
using BankingPanel.Application.Clients.Commands.CreateClient;
using BankingPanel.Contracts.Authentication;
using BankingPanel.Contracts.Client;
using BankingPanel.Contracts.Common;
using BankingPanel.Domain.ClientAggregate;
using BankingPanel.Domain.Common.ValueObjects;
using Mapster;

namespace BankingPanel.Api.Controllers.Commons.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<CreateClientRequest, CreateClientCommand>()
        .Map(dest => dest.sex, src => ParseSex(src.sex))
        .Map(dest => dest.PhoneNumber, src => new PhoneNumber(src.CountryCode, src.Number))
        .Map(dest => dest.Address, src => new Address(src.Country, src.City, src.Street, src.ZibCode));
        

        config.NewConfig<BankAccountRequest, BankAccountCommand>()
            .Map(dest => dest.AccountCurrency, src => ParseCurrency(src.AccountCurrency));

        config.NewConfig<Client, GetClientDetailsResponse>();
        config.NewConfig<BankAccount, BankAccountDetailsResponse>();

        config.NewConfig<PagedResultDto<Client>, PagedResponse<GetClientDetailsResponse>>();


        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
        .Map(dest => dest.Token, src => src.Token)
        .Map(dest => dest, src => src.User);
    }

    private Sex ParseSex(string sex)
    {
        if (Enum.TryParse(sex, true, out Sex parsedSex))
        {
            return parsedSex;
        }
        return Sex.Unknown;
    }

    private AccountCurrency ParseCurrency(string currency)
    {
        if (Enum.TryParse(currency, true, out AccountCurrency parsedSex))
        {
            return parsedSex;
        }
        return AccountCurrency.EGP;
    }
}