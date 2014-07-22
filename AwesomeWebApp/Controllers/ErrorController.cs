using System;
using System.Linq;
using System.Web.Mvc;

namespace AwesomeWebApp.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult Index()
        {
            return View("Error");
        }
    }
}
