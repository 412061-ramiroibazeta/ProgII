using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class DataHelper
    {
        private static DataHelper _instance;
        public SqlConnection _connection;
        private DataHelper()
        {
            _connection = new SqlConnection(Properties.Resources.StrConnection);
        }
        public static DataHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }
        public DataTable ExecuteSP(string sp)
        {
            DataTable dt = new DataTable();
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                dt.Load(cmd.ExecuteReader());
                _connection.Close();
            }
            catch (SqlException)
            {
                // Gestionar la excepción/error
                dt = null;
            }

            
            
            
            return dt;
        }
    }
}
