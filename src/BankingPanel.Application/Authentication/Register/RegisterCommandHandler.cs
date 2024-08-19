using BankingPanel.Application.Authentication.Common;
using BankingPanel.Application.Common.Interfaces;
using BankingPanel.Domain.ApplicationUserAggregate;
using BankingPanel.Domain.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace BankingPanel.Application.Authentication.Register;

public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUsersRepository _usersRepository;

    public RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IPasswordHasher passwordHasher,
        IUsersRepository usersRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _passwordHasher = passwordHasher;
        _usersRepository = usersRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (await _usersRepository.ExistsByEmailAsync(command.Email))
        {
            return Error.Conflict(description: "User already exists");
        }

        var hashPasswordResult = _passwordHasher.HashPassword(command.Password);

        if (hashPasswordResult.IsError)
        {
            return hashPasswordResult.Errors;
        }

        var user = new ApplicationUser(
            command.FirstName,
            command.LastName,
            command.Email,
            hashPasswordResult.Value,
            command.Roles);

        await _usersRepository.AddUserAsync(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}