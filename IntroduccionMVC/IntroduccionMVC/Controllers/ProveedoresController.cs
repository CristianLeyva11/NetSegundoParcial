using Microsoft.AspNetCore.Mvc;

namespace IntroduccionMVC.Controllers
{
    public class ProveedoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
