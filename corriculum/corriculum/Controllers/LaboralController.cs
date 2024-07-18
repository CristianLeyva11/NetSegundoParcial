using Microsoft.AspNetCore.Mvc;

namespace corriculum.Controllers
{
    public class LaboralController : Controller
    {
        public IActionResult Index()
        {
            return View("Laboral");
        }
    }
}
