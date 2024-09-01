using Facturas.Datos.Interfaces;
using Facturas.Datos.Utils;
using Facturas.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturas.Datos.Implementations
{
    public class FacturaRepository : IFacturaRepository
    {
        public bool Save(Factura factura)
        {
            bool aux = true;
            SqlConnection cnn = null;
            SqlTransaction t = null;
            try
            {
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();
                var cmd = new SqlCommand("sp_insertar_factura", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_forma_pago", factura.FormaPago.IdFormaPago);
                cmd.Parameters.AddWithValue("@cliente", factura.Cliente);

                SqlParameter parametro = new SqlParameter("@nro_factura", SqlDbType.Int);
                parametro.Direction = ParameterDirection.Output;                
                cmd.Parameters.Add(parametro);

                cmd.ExecuteNonQuery();

                int nro_factura = (int)parametro.Value;
                int detalleId = 1;
                foreach (var detalle in factura.Detalles)
                {
                    var cmdDetail = new SqlCommand("sp_insert_detalle_factura", cnn, t);
                    cmdDetail.CommandType = CommandType.StoredProcedure;

                    cmdDetail.Parameters.AddWithValue("@id_detalle_factura", detalleId);
                    cmdDetail.Parameters.AddWithValue("@id_factura", nro_factura);
                    cmdDetail.Parameters.AddWithValue("@id_articulo", detalle.Articulo.IdArticulo);
                    cmdDetail.Parameters.AddWithValue("@precio", detalle.Precio);
                    cmdDetail.Parameters.AddWithValue("@cantidad", detalle.Cantidad);

                    cmdDetail.ExecuteNonQuery();

                    detalleId++;
                }
            }
            catch (SqlException)
            {
                if (t == null)
                {
                    t.Rollback();
                    aux = false;
                }
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return aux;
        }        
    }
}
