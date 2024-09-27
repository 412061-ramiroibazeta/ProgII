using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilas
{
    public interface ICollection
    {
        bool EstaVacia();
        object Extraer();
        object Primero();
        bool Aniadir(object obj);
    }
}
