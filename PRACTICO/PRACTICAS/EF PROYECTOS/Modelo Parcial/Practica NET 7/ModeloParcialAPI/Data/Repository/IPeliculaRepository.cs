using ModeloParcialAPI.Data.Models;

namespace ModeloParcialAPI.Data.Repository
{
    public interface IPeliculaRepository
    {
        List<Pelicula> GetPeliculas();
    }
}
