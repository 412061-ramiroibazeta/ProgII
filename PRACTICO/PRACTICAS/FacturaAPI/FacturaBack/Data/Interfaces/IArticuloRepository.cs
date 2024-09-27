﻿using FacturaBack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturaBack.Data.Interfaces
{
    public interface IArticuloRepository
    {
        List<Articulo> GetAll();
        Articulo GetById(int id);
        bool Save(Articulo articulo);
        bool DeleteById(int id);
    }
}