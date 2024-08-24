using Repository.Domain;
using Repository.Services;
using System.Collections.Generic;

ProductServices oService = new ProductServices();

List<Product> lp = oService.GetProducts();

if(lp.Count > 0)
foreach (Product p in lp)
{
    Console.WriteLine(p);
}
else
{
    Console.WriteLine("No hay productos");
}


