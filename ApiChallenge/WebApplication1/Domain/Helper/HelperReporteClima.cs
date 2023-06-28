using Clima.Domain.Entidades;
using Clima.Domain.Repositorio;

namespace Clima.Domain.Helper
{
    public class HelperReporteClima
    {
        private IRepositorioClima Repositorio { get; set; }

        public HelperReporteClima(IRepositorioClima repositorio)
        {
            Repositorio = repositorio;
        }


        public ReporteClima GetReporteClima(string ciudad, string pais, string dia)
        {
            return Repositorio.GetReporteClima(ciudad, pais, dia);
        }

        public List<ReporteClima> GetReporteClimaProximos5Dias(string ciudad, List<string> proximos5Dias)
        {
            return Repositorio.GetReporteClimaProximos5Dias(ciudad, proximos5Dias);
        }
    }
}
