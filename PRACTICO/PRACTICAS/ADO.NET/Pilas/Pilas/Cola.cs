using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilas
{
    public class Cola : ICollection
    {
        public List<object> lst;
        public int Contador { get; set; }

        public Cola()
        {
            lst = new List<object>();
            Contador = 0;
        }

        public bool Aniadir(object obj)
        {
            bool aux = false;
            if (obj != null)
            {
                lst.Add(obj);
                Contador++;
                aux = true;                
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
            object primero = lst.First();
            lst.Remove(0);
            Contador--;
            return primero;
        }

        public object Primero()
        {            
            return lst.First();
        }
    }
}
