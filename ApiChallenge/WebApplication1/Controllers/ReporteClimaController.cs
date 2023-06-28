using Clima.Application.DTO;
using Clima.Application.Queries.Objects;
using Clima.Application.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Clima.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReporteClimaController : ControllerBase
    {
        private ServicioConsultaClima Service { get; set; }
        private readonly ILogger<ReporteClimaController> _logger;

        public ReporteClimaController(ServicioConsultaClima service, ILogger<ReporteClimaController> logger)
        {
            Service = service;
            _logger = logger;
        }

        [HttpGet(Name = "GetReporteClima")]
        public ReporteClimaReadModel Get([FromQuery] ObtenerReporteClimaPorCiudadYPaisQueryObject queryObject)
        {
            try
            {
                ReporteClimaReadModel response = Service.GetReporteClima(queryObject);

                _logger.LogDebug($"Request GetReporteClima, Parámetros: {queryObject.Pais},{queryObject.Ciudad}");

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
