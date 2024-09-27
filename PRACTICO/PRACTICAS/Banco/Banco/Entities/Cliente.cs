using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Entities
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        //public List<Cuenta> Cuentas { get; set; }

        public override string ToString()
        {
            return Nombre + " " + Apellido + " | DNI:" + DNI;
        }
    }
}
