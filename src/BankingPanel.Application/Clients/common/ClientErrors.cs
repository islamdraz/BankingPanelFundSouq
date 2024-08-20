

using ErrorOr;

namespace BankingPanel.Application.Clients.Commands.Common;

public static class ClientErrors
{
    public static Error ClientPersonalIdIsDuplicated => Error.Validation(
        code: "BusinessValidation.Client.ClientPersonalIdIsDuplicated",
        description: "Client with same Personal Id is already exists");
}