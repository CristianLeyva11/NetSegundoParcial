using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Minimal_API___Empresa.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Minimal_API___Empresa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly Todos _context;

        public EmpresaController(Todos context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetProductos()
        {
            var result = await (

                    from e in _context.Empleados
                    join c in _context.Ciudades on e.idCiudad equals c.idCiudad
                    orderby e.nombreEmpleado descending
                    select new
                    {
                        idEmpleado = e.idEmpleado,
                        nombre = e.nombreEmpleado,
                        ciudad = c.nombreCiudad
                    }

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


        // CRUD for Departamento
        //[HttpGet("departamentos")]
        //public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamentos()
        //{
        //    return await _context.Departamentos.ToListAsync();
        //}

        [HttpGet("departamentos/{id}")]
        public async Task<ActionResult<Departamento>> GetDepartamento(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }

            return departamento;
        }

        [HttpPost("departamentos")]
        public async Task<ActionResult<Departamento>> PostDepartamento(Departamento departamento)
        {
            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDepartamento), new { id = departamento.idDepartamento }, departamento);
        }

        [HttpPut("departamentos/{id}")]
        public async Task<IActionResult> PutDepartamento(int id, Departamento departamento)
        {
            if (id != departamento.idDepartamento)
            {
                return BadRequest();
            }

            _context.Entry(departamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("departamentos/{id}")]
        public async Task<IActionResult> DeleteDepartamento(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }

            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartamentoExists(int id)
        {
            return _context.Departamentos.Any(e => e.idDepartamento == id);
        }

        // Endpoints for Empleado
        [HttpGet("empleados")]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            return await _context.Empleados
                .Include(e => e.Ciudad)
                .Include(e => e.EmpleadoDepartamentos)
                .ThenInclude(ed => ed.Departamento)
                .ToListAsync();
        }

        [HttpGet("empleados/{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
            var empleado = await _context.Empleados
                .Include(e => e.Ciudad)
                .Include(e => e.EmpleadoDepartamentos)
                .ThenInclude(ed => ed.Departamento)
                .FirstOrDefaultAsync(e => e.idEmpleado == id);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        [HttpPost("empleados")]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            // Verificar si los departamentos existen antes de asociarlos
            foreach (var empDept in empleado.EmpleadoDepartamentos)
            {
                var departamento = await _context.Departamentos.FindAsync(empDept.idDepartamento);
                if (departamento == null)
                {
                    return BadRequest($"Departamento con id {empDept.idDepartamento} no existe.");
                }
            }

            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.idEmpleado }, empleado);
        }

        [HttpPut("empleados/{id}")]
        public async Task<IActionResult> PutEmpleado(int id, Empleado empleado)
        {
            if (id != empleado.idEmpleado)
            {
                return BadRequest();
            }

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("empleados/{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.idEmpleado == id);
        }
    }
}