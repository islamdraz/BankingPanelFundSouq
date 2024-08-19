using BankingPanel.Domain.ApplicationUserAggregate;

namespace BankingPanel.Application.Authentication.Common;

public record AuthenticationResult(
    ApplicationUser User,
    string Token);