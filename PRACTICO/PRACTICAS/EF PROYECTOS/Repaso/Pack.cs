using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso
{
    public class Pack : Producto
    {
        public int Cantidad { get; set; }
        public Pack() : base()
        {
            Cantidad = 0;
        }
        public override double CalcularPrecio()
        {
            return Precio * Cantidad;
        }
    }
}
