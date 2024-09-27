using Banco.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Repository.Contracts
{
    public interface ITipoCuentaRepository
    {
        List<TipoCuenta> GetAll();
    }
}
