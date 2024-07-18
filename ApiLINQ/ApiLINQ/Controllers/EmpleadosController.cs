using ApiLINQ.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiLINQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly EmpresaContext _context;

        public EmpleadosController(EmpresaContext context)
        {
            _context = context;
        }

        // GET: api/Empleados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetProductos()
        {
            var result = await (

                    from e in _context.Empleados 
                    join c in _context.Ciudades on e.idCiudad equals c.idCiudad
                    orderby e.nombreEmpleado descending
                    select new { idEmpleado = e.idEmpleado, 
                                 nombre = e.nombreEmpleado,
                                 ciudad = c.nombreCiudad} 

                ).ToArrayAsync();

            return Ok(result);

        }


        [HttpGet("listadoEmpleado")]
        public async Task<ActionResult<IEnumerable<EmpleadoDepartamento>>> GetEmpleadoCompleto()
        {

            var result = await (
                
                from ed in _context.EmpleadoDepartamentos 
                join e in _context.Empleados on ed.idEmpleado equals e.idEmpleado
                join d in _context.Departamentos on ed.idDepartamento equals d.idDepartamento
                select new
                {
                    EmpleadoId = e.idEmpleado,
                    DepartamentoId = d.idDepartamento,
                    NombreEmpleado = e.nombreEmpleado,
                    NombreDepartamento = d.nombreDepartamento
                }

                ).ToListAsync();

            return Ok(result);
;
        }


        [HttpGet("listadoDepartamentos")]
        public async Task<ActionResult<IEnumerable<EmpleadoDepartamento>>> GetDepartamentos()
        {

            var result = await (from d in _context.Departamentos
                                select new
                                {
                                    DepartamentoId = d.idDepartamento,
                                    NombreDepartamento = d.nombreDepartamento,
                                    Descripcion = d.descripcion,
                                    Empleados = (from ed in _context.EmpleadoDepartamentos
                                                 where ed.idDepartamento == d.idDepartamento
                                                 select new
                                                 {
                                                     EmpleadoId = ed.Empleado.idEmpleado,
                                                     NombreEmpleado = ed.Empleado.nombreEmpleado,
                                                     FechaIngreso = ed.Empleado.fechaIngreso,
                                                     Puesto = ed.Empleado.puesto,
                                                     Sueldo = ed.Empleado.sueldo,
                                                     Ciudad = ed.Empleado.Ciudad.nombreCiudad
                                                 }).ToList()
                                }).ToListAsync();


            return Ok(result);
            
        }

        [HttpGet("listadoEmpleadoxCiudad")]
        public async Task<ActionResult<IEnumerable<EmpleadoDepartamento>>> GetEmpleadosxciudad()
        {

            var result = await (

                from c in _context.Ciudades
                join e in _context.Empleados on c.idCiudad equals e.idCiudad
                group e by e.idCiudad into cdd
                select new
                {
                    Ciudad = cdd.Key,
                    Empleados = cdd.Count()
                }


                ).ToListAsync();

            return Ok(result);
            
        }


        [HttpGet("listadoSueldoDepartamento")]
        public async Task<ActionResult<IEnumerable<EmpleadoDepartamento>>> GetDepartamento()
        {

            var result = await (from d in _context.Departamentos
                                select new
                                {
                                    DepartamentoId = d.idDepartamento,
                                    NombreDepartamento = d.nombreDepartamento,
                                    PromedioSueldo = (from ed in _context.EmpleadoDepartamentos
                                                      where ed.idDepartamento == d.idDepartamento
                                                      select ed.Empleado.sueldo).Average()
                                }).ToListAsync();

            return Ok(result);
            ;
        }


    }
}
