using Microsoft.AspNetCore.Mvc;

namespace corriculum.Controllers
{
    public class InicioController : Controller
    {
        public IActionResult Index()
        {
            return View("Inicio");
        }
    }
}
