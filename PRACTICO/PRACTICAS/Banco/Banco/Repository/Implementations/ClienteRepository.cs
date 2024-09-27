using Banco.Data;
using Banco.Entities;
using Banco.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Repository.Implementations
{
    public class ClienteRepository : IClienteRepository
    {
        public List<Cliente> GetAll()
        {
            List<Cliente> lst = new List<Cliente>();
            var dt = DataHelper.GetInstance().ExecuteSP("SP_OBTENER_CLIENTES");
            foreach (DataRow row in dt.Rows)
            {
                Cliente c = new Cliente();
                c.IdCliente = (int)row["Id_cliente"];
                c.Nombre = (string)row["nombre"];
                c.Apellido = (string)row["apellido"];
                c.DNI = (int)row["DNI"];
                lst.Add(c);
            }
            return lst;
        }
    }
}
