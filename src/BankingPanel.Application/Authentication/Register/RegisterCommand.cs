using BankingPanel.Application.Authentication.Common;
using ErrorOr;

using MediatR;

namespace BankingPanel.Application.Authentication.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    List<string> Roles) : IRequest<ErrorOr<AuthenticationResult>>;