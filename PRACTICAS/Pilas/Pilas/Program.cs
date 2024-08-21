using Pilas;
using System.Collections.Generic;

var oPila = new Pila(3);

var A = "hola";
var B = "ramiro";
var C = "funciona";


oPila.Aniadir(A);
oPila.Aniadir(B);
Console.WriteLine("-------PILA------");
for (int i = 0; i < oPila.elementos.Length; i++)
{
    Console.WriteLine(oPila.elementos[i]);
}
Console.WriteLine("-------------");
Console.WriteLine(oPila.EstaVacia());
Console.WriteLine("-------------");
Console.WriteLine(oPila.Extraer());
Console.WriteLine("-------------");
Console.WriteLine(oPila.Primero());
Console.WriteLine("-------------");
oPila.Aniadir(C);
Console.WriteLine("-------------");
for (int i = 0; i < oPila.elementos.Length; i++)
{
    Console.WriteLine(oPila.elementos[i]);
}

Console.WriteLine("------COLA-------");

var oCola = new Cola();

oCola.Aniadir(A); oCola.Aniadir(B);

foreach (object o in oCola.lst)
{
    Console.WriteLine(o);
}

Console.WriteLine("-------------");

Console.WriteLine(oCola.EstaVacia());

Console.WriteLine("-------------");

Console.WriteLine(oCola.Primero());

Console.WriteLine("-------------");

