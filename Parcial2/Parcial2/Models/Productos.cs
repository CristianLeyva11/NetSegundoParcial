namespace Parcial2.Models
{
    public class Producto
    {
        public long IdProducto { get; set; }
        public long IdCategoria { get; set; } 
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }

  
        public Categoria Categoria { get; set; }
    }
}
