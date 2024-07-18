namespace Minimal_API___Empresa.Models
{
    public class Ciudad
    {
        public int idCiudad { get; set; }
        public string nombreCiudad { get; set; }
        public ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    }

}
