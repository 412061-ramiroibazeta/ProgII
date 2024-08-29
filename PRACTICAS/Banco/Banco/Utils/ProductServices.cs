using Banco.Entities;
using Banco.Repository.Contracts;
using Banco.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Utils
{
    public class ProductServices
    {
        private IClienteRepository _cliente;

        public ProductServices()
        {
            _cliente = new ClienteRepository();
        }
        public List<Cliente> GetClientes()
        {
            return _cliente.GetAll();
        }
    }
}
