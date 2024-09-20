using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioTurno.Entities
{
    public class Turno
    {
        public int IdTurno { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Cliente { get; set; }
        public List<DetalleTurno> Detalles { get; set; } = new List<DetalleTurno>();

        public bool AniadirDetalle(DetalleTurno detalle)
        {
            bool aux = true;
            foreach (DetalleTurno d in Detalles)
            {
                if (d.Servicio == detalle.Servicio)
                {
                    aux = false;
                    break;
                }
                else
                {
                    Detalles.Add(d);
                }
            }
                return aux;
        }

    }
}
