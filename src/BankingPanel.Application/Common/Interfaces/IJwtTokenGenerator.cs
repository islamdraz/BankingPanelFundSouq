
using BankingPanel.Domain.ApplicationUserAggregate;

namespace BankingPanel.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(ApplicationUser user);
}