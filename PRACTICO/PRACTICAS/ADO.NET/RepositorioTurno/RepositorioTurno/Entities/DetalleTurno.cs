using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioTurno.Entities
{
    public class DetalleTurno
    {
        public int IdTurno { get; set; }
        public int Servicio { get; set; }
        public string Observaciones { get; set; }
    }
}
