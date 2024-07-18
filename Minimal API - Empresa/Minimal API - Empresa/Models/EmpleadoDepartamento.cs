using System.Text.Json.Serialization;

namespace Minimal_API___Empresa.Models
{
    public class EmpleadoDepartamento
    {
        public int idEmpleado { get; set; }
        [JsonIgnore]
        public virtual Empleado? Empleado { get; set; }
        public int idDepartamento { get; set; }
        public virtual Departamento? Departamento { get; set; }
    }

}
