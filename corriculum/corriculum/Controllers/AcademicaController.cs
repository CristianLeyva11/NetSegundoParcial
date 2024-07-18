using Microsoft.AspNetCore.Mvc;

namespace corriculum.Controllers
{
    public class AcademicaController : Controller
    {
        public IActionResult Index()
        {
            return View("Academica");
        }
    }
}
