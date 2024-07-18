using Microsoft.AspNetCore.Mvc;

namespace IntroduccionMVC.Controllers
{
    public class InicioController : Controller
    {
        public string Index()
        {
            return "Mi orimer controllador mi pai";
        }
        // GET: Buscar
        public ActionResult Buscar(string nombre)
        {
            return Content("El nombre que buscas es: " + nombre);
        }

        //GET: Redireccionar
        public ActionResult Redirecciona()
        {
            return RedirectToAction("ListaProveedores", "Proveedores");
        }
    }
}
