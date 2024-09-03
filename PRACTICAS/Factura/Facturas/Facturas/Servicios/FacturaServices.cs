﻿using Facturas.Datos.Implementations;
using Facturas.Datos.Interfaces;
using Facturas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturas.Servicios
{
    public class FacturaServices
    {
        private IFacturaRepository _facturaRepository;
        public FacturaServices()
        {
            _facturaRepository = new FacturaRepository();
        }

        public bool Save(Factura factura)
        {
            return _facturaRepository.Save(factura);
        }
    }
}
