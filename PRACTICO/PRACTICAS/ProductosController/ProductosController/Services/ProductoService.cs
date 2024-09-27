using ProductosController.Models;

namespace ProductosController.Services
{
    public class ProductoService : IAplicacion
    {
        public static List<Productos> lst { get; set; } = new List<Productos>();
        
        public bool AgregarProducto(Productos producto)
        {
            bool aux = false;
            if (producto != null)
            {
                lst.Add(producto);
                aux = true;
            }
            return aux;
        }

        public bool EditarProducto(Productos p)
        {
            throw new NotImplementedException();
        }

        public bool EliminarProducto(int id)
        {
            var p = lst.Find(p => p.Codigo == id);
            if (p != null)
            {
                lst.Remove(p);
                return true;
            }
            return false;
        }

        public List<Productos> GetProductos()
        {
            return lst;
        }
    }
}
