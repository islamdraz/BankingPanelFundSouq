using BankingPanel.Application.Clients.Commands.CreateClient;
using BankingPanel.Application.Clients.Queries;
using BankingPanel.Contracts.Client;
using BankingPanel.Contracts.Client.Query;
using BankingPanel.Contracts.Common;
using BankingPanel.Domain.ClientAggregate;
using BankingPanel.Domain.Common.ValueObjects;
using Mapster;

namespace BankingPanel.Api.Controllers.Commons.Mapping;

public class ClientMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateClientRequest, CreateClientCommand>()
        .Map(dest => dest.Sex, src => ParseSex(src.Sex))
        .Map(dest => dest.PhoneNumber, src => new PhoneNumber(src.CountryCode, src.Number))
        .Map(dest => dest.Address, src => new Address(src.Country, src.City, src.Street, src.ZibCode));
        

        config.NewConfig<SearchClientRequest, SearchClientQuery>();
        
        config.NewConfig<BankAccountRequest, BankAccountCommand>()
            .Map(dest => dest.AccountCurrency, src => ParseCurrency(src.AccountCurrency));

        config.NewConfig<Client, GetClientDetailsResponse>();
        config.NewConfig<BankAccount, BankAccountDetailsResponse>();

        config.NewConfig<PagedResultDto<Client>, PagedResponse<GetClientDetailsResponse>>();

        config.NewConfig<Client, GetClientDetailsResponse>()
        // Map Address Value object
        .Map(dest => dest.Sex, src => src.Sex.ToString())
        .Map(dest => dest.City, src => src.Address.City)
        .Map(dest => dest.Street, src => src.Address.Street)
        .Map(dest => dest.ZibCode, src => src.Address.ZibCode)
        .Map(dest => dest.Country, src => src.Address.Country)
        // Map phone Number Value object
        .Map(dest => dest.Number, src => src.PhoneNumber.Number)
        .Map(dest => dest.CountryCode, src => src.PhoneNumber.CountryCode);

        config.NewConfig<Client, CreateClientResponse>()
        // Map Address Value object
        .Map(dest => dest.Sex, src => src.Sex.ToString())
        .Map(dest => dest.City, src => src.Address.City )
        .Map(dest => dest.Street, src => src.Address.Street)
        .Map(dest => dest.ZibCode, src => src.Address.ZibCode)
        .Map(dest => dest.Country, src => src.Address.Country)
        // Map phone Number Value object
        .Map(dest => dest.Number, src => src.PhoneNumber.Number)
        .Map(dest => dest.CountryCode, src => src.PhoneNumber.CountryCode);


        config.NewConfig<BankAccount, BankAccountResponse>();
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