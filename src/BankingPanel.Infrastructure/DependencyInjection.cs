using BankingPanel.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BankingPanel.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddPersistence();
        return services;
    }

    static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<BankingPanelDbContext>(options =>
            options.UseSqlite("Data Source = BankingPanel.db"));

        // Configure Identity with default IdentityUser and IdentityRole
            // services.AddIdentity<IdentityUser, IdentityRole>()
            //     .AddEntityFrameworkStores<ApplicationDbContext>()
            //     .AddDefaultTokenProviders();
        return services;
    }



}