namespace Clima.Application.DTO
{
    public class ReporteClimaReadModel
    {
        public int Id { get; set; }
        public string DiaSemana { get; set; }
        public decimal Humedad { get; set; }
        public decimal VelocidadViento { get; set; }
        public decimal ProbPrecipitaciones { get; set; }
        public decimal Grados { get; set; }
        public string Estado { get; set; }
        public int Ciudad { get; set; }
        public int Pais { get; set; }
    }
}
