using BankingPanel.Application.Authentication.Common;
using ErrorOr;

using MediatR;

namespace BankingPanel.Application.Authentication.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;