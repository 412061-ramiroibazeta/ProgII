namespace TemperaturaAPI.Models
{
    public class Temperatura
    {
        public int Identificador { get; set; }
        public DateTime FechaHora { get; set; } = DateTime.Now;
        public float Valor { get; set; }
    }
}
