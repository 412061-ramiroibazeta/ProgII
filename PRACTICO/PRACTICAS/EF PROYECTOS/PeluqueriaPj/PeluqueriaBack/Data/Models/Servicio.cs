﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace PeluqueriaBack.Data.Models;

public partial class Servicio
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public int Costo { get; set; }

    public string EnPromocion { get; set; }

    public virtual ICollection<DetallesTurno> DetallesTurnos { get; set; } = new List<DetallesTurno>();
}