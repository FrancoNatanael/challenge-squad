using Clima.Domain.Entidades;
using Clima.Domain.Repositorio;
using Clima.Infrastructure.Context;

namespace Clima.Infrastructure.RepositorioEF
{
    public class ClimaRepositorio : IRepositorioClima
    {

        public ClimaRepositorio()
        {
        }

        public ReporteClima GetReporteClima(string ciudad, string pais, string dia)
        {
            using (var Contexto = new ClimaContexto())
            {

                var reporteClima = from reporteObj in Contexto.ReporteClima
                                   join paisObj in Contexto.Pais
                                   on reporteObj.Pais equals paisObj.Id
                                   join ciudadObj in Contexto.Ciudad
                                   on paisObj.Id equals ciudadObj.IdPais
                                   where paisObj.Nombre == pais && ciudadObj.Nombre == ciudad && reporteObj.DiaSemana.ToLower() == dia
                                   select new ReporteClima
                                   {
                                       Id = reporteObj.Id,
                                       DiaSemana = reporteObj.DiaSemana,
                                       Humedad = reporteObj.Humedad,
                                       VelocidadViento = reporteObj.VelocidadViento,
                                       ProbPrecipitaciones = reporteObj.ProbPrecipitaciones,
                                       Grados = reporteObj.Grados,
                                       Estado = reporteObj.Estado,
                                       Ciudad = reporteObj.Ciudad,
                                       Pais = reporteObj.Pais
                                   };

                return reporteClima.ToList().FirstOrDefault();
            }
        }

        public List<ReporteClima> GetReporteClimaProximos5Dias(string ciudad, List<string> proximos5Dias)
        {
            using (var Contexto = new ClimaContexto())
            {
                var reporteClima = (from reporteObj in Contexto.ReporteClima
                                    join ciudadObj in Contexto.Ciudad
                                    on reporteObj.Ciudad equals ciudadObj.Id
                                    where ciudadObj.Nombre == ciudad && proximos5Dias.Contains(reporteObj.DiaSemana.ToLower())
                                    select new ReporteClima
                                    {
                                        Id = reporteObj.Id,
                                        DiaSemana = reporteObj.DiaSemana,
                                        Humedad = reporteObj.Humedad,
                                        VelocidadViento = reporteObj.VelocidadViento,
                                        ProbPrecipitaciones = reporteObj.ProbPrecipitaciones,
                                        Grados = reporteObj.Grados,
                                        Estado = reporteObj.Estado,
                                        Ciudad = reporteObj.Ciudad,
                                        Pais = reporteObj.Pais
                                    }).ToList().DistinctBy(x => x.DiaSemana);

                return reporteClima.ToList();
            }
        }
    }
}
