using Clima.Domain.Entidades;

namespace Clima.Domain.Repositorio
{
    public interface IRepositorioClima
    {
        public ReporteClima GetReporteClima(string ciudad, string pais, string dia);
        public List<ReporteClima> GetReporteClimaProximos5Dias(string ciudad, List<string> proximos5Dias);
    }
}
