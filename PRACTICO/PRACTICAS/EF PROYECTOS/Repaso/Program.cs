// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using Repaso;

//object p = new Pack();
//object s = new Suelto();

//object[] productos = { p, s };

var pack = new Pack();
pack.Precio = 100;
pack.Cantidad = 2;
pack.Nombre = "Mi pack";

var suelto = new Suelto();
suelto.Precio = 500;
suelto.Medida = 4;
suelto.Nombre = "Mi suelto";

Producto[] productos = {pack, suelto};

double total = 0;
foreach (Producto o in productos)
{
    Console.WriteLine(o);
    total += o.CalcularPrecio();
}
