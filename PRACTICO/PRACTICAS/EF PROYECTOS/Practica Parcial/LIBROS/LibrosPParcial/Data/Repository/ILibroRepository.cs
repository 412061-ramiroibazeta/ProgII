using LibrosPParcial.Data.Models;
using System.ComponentModel.DataAnnotations;

//--1) Todos los libros disponibles
//--2) Validar campos obligatorios al insertar un libro, debe estar disponible al insertarse
//--3) Consultar libros por autor 
//--4) Consultar libros por categoría
//--5) Consultar libros por fecha de publicación
//--6) Al editar un libro se debe sacar de disponibilidad

namespace LibrosPParcial.Data.Repository
{
    public interface ILibroRepository
    {
        List<Libro> GetAllDispo();
        List<Libro> GetByAutor(string autor);
        List<Libro> GetByCategoria(int categoriaId);
        List<Libro> GetBetween(DateTime fechaInicio, DateTime fechaHasta);
        bool Save(Libro libro);        
        bool UpdateLibro(Libro libro);  

    }
}
