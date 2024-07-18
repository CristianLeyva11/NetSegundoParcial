using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text.Encodings.Web;

namespace MvcMovies.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hola "+ name;
            ViewData["numTimes"] = numTimes;
            return View();
        }
    }
}
