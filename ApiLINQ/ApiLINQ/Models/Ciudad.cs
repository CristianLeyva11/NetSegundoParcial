using System.Text.Json.Serialization;

namespace ApiLINQ.Models
{
    public class Ciudad
    {
        public int idCiudad { get; set; }
        public string nombreCiudad { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
