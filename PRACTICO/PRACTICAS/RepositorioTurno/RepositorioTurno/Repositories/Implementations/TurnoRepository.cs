using RepositorioTurno.Entities;
using RepositorioTurno.Repositories.Interfaces;
using RepositorioTurno.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioTurno.Repositories.Implementations
{
    public class TurnoRepository : ITurnoRepository
    {
        public int ContarTurnos(string fecha, string hora)
        {
            int CantidadTurnos = -1;
            var lst = new List<SqlParameter>();

            var dt = new DataTable();

            lst.Add(new SqlParameter("@fecha", fecha));
            lst.Add(new SqlParameter("@hora", hora));
            var param = new SqlParameter("@ctd_turnos", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;

            lst.Add(param);

            dt = DataHelper.GetInstance().ExecuteSPGet("SP_CONTAR_TURNOS", lst);

            CantidadTurnos = Convert.ToInt32(param.Value);

            return CantidadTurnos;

        }

        public bool InsertarMaestroDetalle(Turno turno)
        {
            bool aux = false;
            SqlConnection cnn = null;
            SqlTransaction t = null;
            try
            {
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();
                t = cnn.BeginTransaction();
                var cmd = new SqlCommand("SP_INSERTAR_MAESTRO", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("fecha", turno.Fecha);
                cmd.Parameters.AddWithValue("hora", turno.Hora);
                cmd.Parameters.AddWithValue("cliente", turno.Cliente);

                SqlParameter param = new SqlParameter("id", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                int id = Convert.ToInt32(param.Value);
                int detalleId = 1;

                var cmdTurno = new SqlCommand("SP_INSERTAR_DETALLES", cnn, t);
                cmdTurno.CommandType = CommandType.StoredProcedure;

                foreach (var d in turno.Detalles)
                {
                    cmdTurno.Parameters.AddWithValue("@id_turno", id);
                    cmdTurno.Parameters.AddWithValue("@id_servicio", d.Servicio);
                    cmdTurno.Parameters.AddWithValue("@observaciones", d.Observaciones);

                    cmdTurno.ExecuteNonQuery();

                }



            }
            catch (SqlException)
            {

                throw;
            }
        }

        public List<Servicio> ObtenerServicios()
        {
            var dt = new DataTable();
            var lst = new List<Servicio>();

            dt = DataHelper.GetInstance().ExecuteSPGet("SP_CONSULTAR_SERVICIOS", null);

            foreach (DataRow d in dt.Rows)
            {
                var s = new Servicio();

                s.Id = Convert.ToInt32(d["id"]);
                s.Nombre = Convert.ToString(d["nombre"]);
                s.Costo = Convert.ToInt32(d["costo"]);
                s.EnPromocion = Convert.ToString(d["enPromocion"]);

                lst.Add(s);
            }
            return lst;
        }
    }
}
