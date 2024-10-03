using ModeloParcialAPI.Data.Models;

namespace ModeloParcialAPI.Data.Repository
{
    public interface IPeliculaRepository
    {
        List<Pelicula> GetPeliculas();
        bool Save(Pelicula p);
        bool Update(int id, string motivo);
        List<Pelicula> GetFueraEstreno(int anioDesde, int anioHasta);
    }
}
