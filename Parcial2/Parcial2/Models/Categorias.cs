namespace Parcial2.Models
{
    public class Categoria
    {
        public long IdCategoria { get; set; }
        public string Nombre { get; set; }
        public ICollection<Producto> Productos { get; set; }
    }
}
