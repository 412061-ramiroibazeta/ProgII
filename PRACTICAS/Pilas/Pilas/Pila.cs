using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;

namespace Pilas
{
    public class Pila : ICollection
    {
        public int Contador { get; set; }
        public Object[] elementos;

        public Pila(int tam)
        {
            elementos = new object[tam];
            Contador = 0;
        }


        public bool Aniadir(object obj)
        {
            bool aux = false;
 
            if (elementos.Length > Contador)
            {
                elementos[Contador] = obj;
                aux = true;
                Contador++;
            }
            return aux;
        }

        public bool EstaVacia()
        {
            bool aux = false;
            if (Contador == 0)
            {
                aux = true;
            }
            return aux;
        }

        public object Extraer()
        {
            object aux = elementos[0];
            elementos[0] = null;

            for (int i = 0; i < Contador; i++)
            {
                if (i != Contador - 1)
                {
                    elementos[i] = elementos[i + 1];
                }
                if (i == Contador - 1)
                {
                    elementos[i-1] = elementos[i];
                    elementos[i] = null;

                    Contador--;
                }
            }
            return aux;
        }

        public object Primero()
        {
            return elementos[0];
        }
    }
}
