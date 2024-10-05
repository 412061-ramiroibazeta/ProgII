using EnviosWebApi.Models;

namespace EnviosWebApi.Repository.Contracts
{
    public interface IEnvioRepository
    {
        // Consultar entre fechas y que esten cancelados
        // Post validando datos //practicar por ejemplo post con fecha no menor a x
        // delete para cancelar

        //List<TEnvio> GetAll();
        //TEnvio Get(int id);
        //List<TEnvio> GetByCliente(string DNI);
        List<TEnvio> GetByFechaNoCancel(DateTime fechaDesde, DateTime fechaHasta);
        bool Save(TEnvio envio);
        bool Delete(int idEnvio);

    }
}
