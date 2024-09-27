using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso
{
    public class Suelto : Producto
    {
        public int Medida { get; set; }
        public Suelto() : base()
        {
            Medida = 0;
        }
        public override double CalcularPrecio()
        {
            return Precio * Medida;
        }
    }
}
