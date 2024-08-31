using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturas.Dominio
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public int Nombre { get; set; }
        public int PrecioUnitario { get; set; }
    }
}
