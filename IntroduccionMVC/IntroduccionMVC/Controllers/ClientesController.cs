using IntroduccionMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntroduccionMVC.Controllers
{
    public class ClientesController : Controller
    {
        public static List<Cliente> ListaClientes = new List<Cliente>
        {
            new Cliente
            {
                Id = 1,
                Nombre = "Cristian",
                FechaAlta = DateTime.Parse(DateTime.Today.ToString()),
                Correo = "cristianleyvacr7@gmail.com"
            },
            new Cliente
            {
                Id = 2,
                Nombre = "Blanca",
                FechaAlta = DateTime.Parse(DateTime.Today.ToString()),
                Correo = "BlancaGuzman@gmail.com"
            },
        };
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pedidos()
        {
            return View();
        }
        public IActionResult ListadoClientes()
        {
            return View(ListaClientes);
        }
        public IActionResult create()
        {
            return View();
        }

        //POST : CLientes/create
        [HttpPost]
        public IActionResult create(Cliente cliente)
        {
            try
            {
                //Agregamos el nueevo xliente al modelo
                ListaClientes.Add(cliente);
                return RedirectToAction("ListadoClientes");
            }catch(Exception e)
            {

                return View();
            }
        }
    }
}
