using System.Text.Json.Serialization;

namespace ApiLINQ.Models
{
    public class EmpleadoDepartamento
    {
        public int idEmpleado { get; set; }
        public Empleado Empleado { get; set; }

        public int idDepartamento { get; set; }
        public Departamento Departamento { get; set; }
    }
}
