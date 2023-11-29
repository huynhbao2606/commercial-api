using AzureAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace AzureAPI.Controllers
{
    [ApiController]
    [Route("/errors/{code}")]
    public class HandleErrorController : ControllerBase
    {


        public IActionResult Error(int code)
        {
            return new ObjectResult(new ErrorResponse(code));
        }

    }
}
