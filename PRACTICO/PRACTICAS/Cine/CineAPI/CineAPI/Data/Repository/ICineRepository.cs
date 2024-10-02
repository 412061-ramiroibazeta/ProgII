using CineAPI.Data.Models;
using Microsoft.Win32;
using System;

namespace CineAPI.Data.Repository
{
    public interface ICineRepository
    {
        //peliculas en estreno
        //Recuperar todos las peliculas que estuvieron en estreno entre dos años recibidos como parámetro.
        //Modificar la base de datos y agregar las columnas: fechaBaja y motivo de baja como nulleables para registrar mediante Delete una baja lógica de la pelicula
        List<Pelicula> GetPeliculas();
        bool Save(Pelicula p);
        bool Update(Pelicula p);  
        List<Pelicula> GetByFilters(int anioInicio, int anioFin);
    }
}
