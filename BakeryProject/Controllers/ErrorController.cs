using Microsoft.AspNetCore.Mvc;

namespace BakeryProject.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewData["Error"] = "404: Not Found";
                    ViewData["ErrorMessage"] = "Sorry, the resource you are requested could not be found.";
                    break;
                case 400:
                    ViewData["Error"] = "400: Bad Request";
                    ViewData["ErrorMessage"] = "Sorry, The request could not be understood by server or Invalid Url";
                    break;
            }
            return View("StatusError");
        }
    }
}
