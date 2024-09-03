using Facturas.Datos.Implementations;
using Facturas.Dominio;
using Facturas.Servicios;

Articulo articulo1 = new Articulo { IdArticulo = 1, Nombre = "Laptop", PrecioUnitario = 1000 };
Articulo articulo2 = new Articulo { IdArticulo = 2, Nombre = "Teclado", PrecioUnitario = 50 };

var articuloService = new ArticuloServices();

articuloService.Save(articulo1);
articuloService.Save(articulo2);

DetalleFactura detalle1 = new DetalleFactura
{
    Articulo = articulo1,
    Precio = 1000,
    Cantidad = 1
};

DetalleFactura detalle2 = new DetalleFactura
{
    Articulo = articulo2,
    Precio = 50,
    Cantidad = 2
};

DetalleFactura detalle3 = new DetalleFactura
{
    Articulo = articulo1,
    Precio = 1000,
    Cantidad = 1
};

Factura factura = new Factura
{
    FormaPago = new FormaPago { IdFormaPago = 1, FormaDePago = "Efectivo" },
    Cliente = "Ramiro"
};

factura.AniadirDetalle(detalle1);
factura.AniadirDetalle(detalle2);
factura.AniadirDetalle(detalle3); //pruebo si el verificador de articulos en detalle duplicados funciona


Console.WriteLine($"Cliente: {factura.Cliente}, Forma de Pago: {factura.FormaPago.FormaDePago}");
Console.WriteLine("Detalles de la factura antes de guardar:");
foreach (var detalle in factura.Detalles)
{
    Console.WriteLine($"Artículo: {detalle.Articulo.Nombre}, Cantidad: {detalle.Cantidad}, Precio: {detalle.Precio}, Subtotal: {detalle.Subtotal()}");
}


var repo = new FacturaServices();
bool resultado = repo.Save(factura);

Console.WriteLine("Factura guardada exitosamente: " + resultado);
