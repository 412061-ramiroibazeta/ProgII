using ProductosController.Models;

namespace ProductosController.Services
{
    public interface IAplicacion
    {
        List<Productos> GetProductos();
        bool AgregarProducto(Productos producto);
        bool EliminarProducto(int id);
        bool EditarProducto(Productos p);
    }
}
