using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;
using BankingPanel.Api.Controllers.Commons.Errors.Http;

namespace BankingPanel.Api.Controllers;

[Authorize]
[ApiController]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        // means their an erorr but this error is not something you throw 
        if (errors.Count is 0)
        {
            return Problem();
        }
        // return my domain validation errors 
        if (errors.All(error => error.Type == ErrorType.Validation))
        {
            return ValidationProblem(errors);

        }
        HttpContext.Items[HttpContextItemKeys.Errors] = errors;
        var firstError = errors[0];

        return Problem(firstError);
    }

    private IActionResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError

        };

        return Problem(statusCode: statusCode, title: error.Description);
    }

    private IActionResult ValidationProblem(List<Error> errors)
    {
        var modelStateDictionary = new ModelStateDictionary();

        foreach (var error in errors)
        {
            modelStateDictionary.AddModelError(error.Code,
                                               error.Description);
        }
        return ValidationProblem(modelStateDictionary);
    }
}