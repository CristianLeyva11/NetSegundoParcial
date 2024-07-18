using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial2.Data;
using Parcial2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parcial2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly BDProyectoContext _context;

        public ProductoController(BDProyectoContext context)
        {
            _context = context;
        }

        // GET: api/Producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }
        [HttpGet("filtrar")]
        public async Task<ActionResult<IEnumerable<Producto>>> FiltrarProductosPorLetra(char letra)
        {
            var productos = await _context.Productos
                .Where(p => p.Nombre.StartsWith(letra.ToString()))
                .ToListAsync();

            return productos;
        }
    }
}
