using System.Text.Json.Serialization;

namespace ApiLINQ.Models
{
    public class Empleado
    {
        public int idEmpleado {  get; set; }
        public string nombreEmpleado { get; set; }
        public DateTime fechaIngreso { get; set; }
        public string puesto {  get; set; }
        public double sueldo { get; set; }
        public int idCiudad { get; set; }
        public virtual Ciudad Ciudad{ get; set; }
        
        [JsonIgnore]
        public ICollection<EmpleadoDepartamento> EmpleadoDepartamentos { get; set; }
    }
}
