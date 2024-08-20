using BankingPanel.Application.Common.Interfaces;
using BankingPanel.Domain.Common.Interfaces;
using BankingPanel.Infrastructure.Authentication.TokenGenerator;
using BankingPanel.Infrastructure.Persistence;
using BankingPanel.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserManagement.Api.Authentication.PasswordHasher;
using UserManagement.Api.Authentication.TokenGenerator;

namespace BankingPanel.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAuth(configuration);
        services.AddPersistence();
        return services;
    }

    static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<BankingPanelDbContext>(options =>
            options.UseSqlite("Data Source = BankingPanel.db"));


        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services,
                                           ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.Section, jwtSettings);
        services.AddSingleton(Options.Create(jwtSettings));


        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IClientsRepository, ClientsRepository>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGererator>();
        services.AddSingleton<IPasswordHasher, PasswordHasher>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,  // we pass what we define as valide issuer and audience 
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtSettings.Secret))

                    });
        return services;
    }

}