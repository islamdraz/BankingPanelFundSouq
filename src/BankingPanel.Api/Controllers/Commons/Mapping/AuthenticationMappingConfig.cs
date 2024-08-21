
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
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
        .Map(dest => dest.Token, src => src.Token)
        .Map(dest => dest, src => src.User);
    }

  
}