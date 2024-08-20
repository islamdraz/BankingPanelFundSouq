using Microsoft.AspNetCore.Mvc;

namespace BankingPanel.Api.Controllers;

public class ErrorsController : ControllerBase
{

    [Route("/error")]
    [HttpPost]
    public IActionResult Error()
    {
        return Problem();
    }


}