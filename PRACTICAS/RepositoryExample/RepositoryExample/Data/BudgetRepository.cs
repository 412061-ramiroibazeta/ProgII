using RepositoryExample.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryExample.Data
{
    public class BudgetRepository : IBudgetRepository
    {
        public List<Budget> GetAll()
        {
            throw new NotImplementedException();
        }

        public Budget GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Budget budget)
        {
            bool result = true;
            SqlConnection cnn = null;
            SqlTransaction t = null;
            try
            {
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();
                var cmd = new SqlCommand("SP_INSERTAR_MAESTRO", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cliente", budget.Client);
                cmd.Parameters.AddWithValue("@vigencia", budget.Expiration);
                
                SqlParameter param = new SqlParameter("@id", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();

                int budgetId = (int)param.Value;
                int detailId = 1;
                foreach (var detail in budget.Details)
                {
                    var cmdDetail = new SqlCommand("SP_INSERTAR_DETALLES", cnn, t);
                    cmdDetail.CommandType = CommandType.StoredProcedure;

                    cmdDetail.Parameters.AddWithValue("@detalle", detailId);
                    cmdDetail.Parameters.AddWithValue("@presupuesto", budgetId);
                    cmdDetail.Parameters.AddWithValue("@producto", detail.Product.Codigo);
                    cmdDetail.Parameters.AddWithValue("@cantidad", detail.Count);
                    cmdDetail.Parameters.AddWithValue("@precio", detail.Price);
                    
                    cmdDetail.ExecuteNonQuery();
                    
                    detailId++;
                }
            }
            catch (SqlException)
            {
                if (t == null)
                {
                    t.Rollback();
                    result = false;
                }
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return result;
        }
    }
}
