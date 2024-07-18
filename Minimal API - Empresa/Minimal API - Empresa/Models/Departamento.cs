using System.Text.Json.Serialization;

namespace Minimal_API___Empresa.Models
{
    public class Departamento
    {
        public int idDepartamento { get; set; }
        public string nombreDepartamento { get; set; }
        public string descripcion { get; set; }

        [JsonIgnore]
        public ICollection<EmpleadoDepartamento> EmpleadoDepartamentos { get; set; } = new List<EmpleadoDepartamento>(); // Inicialización
    }
}
