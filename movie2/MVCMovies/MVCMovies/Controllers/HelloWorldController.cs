using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MVCMovies.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome(string name, int ID = 4)
        {
            ViewData["mensaje"] = "Hola" + name;
            ViewData["id"] = ID;
            return View();
        }
    }
}
