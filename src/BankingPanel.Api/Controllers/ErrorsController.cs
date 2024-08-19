using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

public class ErrorsController : ControllerBase
{

    [Route("/error")]
    [HttpPost]
    public IActionResult Error()
    {
        return Problem();
    }


}