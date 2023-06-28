using Clima.Application.DTO;
using Clima.Application.Queries.Objects;
using Clima.Application.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Clima.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReporteClima5DiasController : ControllerBase
    {
        private ServicioConsultaClima Service { get; set; }
        private readonly ILogger<ReporteClima5DiasController> _logger;

        public ReporteClima5DiasController(ServicioConsultaClima service, ILogger<ReporteClima5DiasController> logger)
        {
            Service = service;
            _logger = logger;
        }

        [HttpGet(Name = "GetReporteClima5Dias")]
        public IEnumerable<ReporteClimaReadModel> Get([FromQuery] ObtenerReporteClimaPorCiudadQueryObject queryObject)
        {
            try
            {
                List<ReporteClimaReadModel> response = Service.GetReporteClimaProximos5Dias(queryObject);

                _logger.LogDebug($"Request GetReporteClima5Dias, Parámetros: {queryObject.Ciudad}");

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw new Exception("Error al intentar obtener el reporte del clima.");
            }
        }
    }
}
