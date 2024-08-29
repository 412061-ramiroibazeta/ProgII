using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Entities
{
    public class Cuenta
    {
        public int Id { get; set; }
        public int CBU { get; set; }
        public double Saldo { get; set; }
        public int TipoCuenta { get; set; }
        public DateTime UltimoMovimiento { get; set; }
        public int Cliente { get; set; }

    }
}
