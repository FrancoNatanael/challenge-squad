using Clima.Application.DTO;
using Clima.Application.Queries.Objects;
using Clima.Domain.Entidades;
using Clima.Domain.Helper;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Clima.Application.Servicios
{
    public class ServicioConsultaClima
    {
        private HelperReporteClima HelperConsulta;
        private List<string> dias = new() { "lunes", "martes", "miercoles", "jueves", "viernes", "sabado", "domingo" };

        public ServicioConsultaClima(HelperReporteClima helperConsulta)
        {
            HelperConsulta = helperConsulta;
        }

        public ReporteClimaReadModel GetReporteClima(ObtenerReporteClimaPorCiudadYPaisQueryObject queryObject)
        {
            string diaActual = ObtenerDiaActual();
            ReporteClima reporteClima = HelperConsulta.GetReporteClima(queryObject.Ciudad, queryObject.Pais, diaActual);

            ReporteClimaReadModel reporteClimaReadModel = new ReporteClimaReadModel()
            {
                Id = reporteClima.Id,
                DiaSemana = reporteClima.DiaSemana,
                Humedad = reporteClima.Humedad,
                VelocidadViento = reporteClima.VelocidadViento,
                ProbPrecipitaciones = reporteClima.ProbPrecipitaciones,
                Grados = reporteClima.Grados,
                Ciudad = reporteClima.Ciudad,
                Pais = reporteClima.Pais
            };

            return reporteClimaReadModel;
        }

        public List<ReporteClimaReadModel> GetReporteClimaProximos5Dias(ObtenerReporteClimaPorCiudadQueryObject queryObject)
        {
            string diaActual = ObtenerDiaActual();
            List<string> proximos5Dias = ObtenerProximos5Dias(diaActual);
            List<ReporteClima> reportesClima = HelperConsulta.GetReporteClimaProximos5Dias(queryObject.Ciudad, proximos5Dias);
            List<ReporteClimaReadModel> reportesClimaReadModel = new();

            foreach (ReporteClima reporteClima in reportesClima)
            {
                ReporteClimaReadModel reporteClimaReadModel = new ReporteClimaReadModel()
                {
                    Id = reporteClima.Id,
                    DiaSemana = reporteClima.DiaSemana,
                    Humedad = reporteClima.Humedad,
                    VelocidadViento = reporteClima.VelocidadViento,
                    ProbPrecipitaciones = reporteClima.ProbPrecipitaciones,
                    Grados = reporteClima.Grados,
                    Ciudad = reporteClima.Ciudad,
                    Pais = reporteClima.Pais
                };

                reportesClimaReadModel.Add(reporteClimaReadModel);
            }

            return ObtenerListaOrdenadaPorDia(reportesClimaReadModel,proximos5Dias);
        }

        public string ObtenerDiaActual()
        {
            CultureInfo culture = new CultureInfo("es-ES");
            string dia = culture.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek);
            string diaSinTilde = Regex.Replace(dia.Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "");

            return diaSinTilde;
        }

        public List<string> ObtenerProximos5Dias(string diaActual)
        {
            List<string> proximosDias = new();
            int indiceDiaActual = dias.IndexOf(diaActual);

            for (int i = indiceDiaActual + 1; i < dias.Count; i++)
            {
                if (proximosDias.Count < 5)
                {
                    proximosDias.Add(dias[i]);
                }
            }

            if (proximosDias.Count < 5)
            {
                for (int i = 0; i < dias.Count; i++)
                {
                    if (dias[i] != diaActual && proximosDias.Count < 5)
                    {
                        proximosDias.Add(dias[i]);
                    }
                }
            }

            return proximosDias;
        }

        public List<ReporteClimaReadModel> ObtenerListaOrdenadaPorDia(List<ReporteClimaReadModel> listaReporte, List<string> proximos5Dias)
        {
            List<ReporteClimaReadModel> listaOrdenada = new();
            ReporteClimaReadModel[] reportes = new ReporteClimaReadModel[5];

            for (int i = 0; i < 5; i++)
            {
                reportes[proximos5Dias.IndexOf(listaReporte[i].DiaSemana.ToLower())] = listaReporte[i];

            }

            foreach (ReporteClimaReadModel reporte in reportes)
            {
                listaOrdenada.Add(reporte);
            }

            return listaOrdenada;
        }
    }
}
