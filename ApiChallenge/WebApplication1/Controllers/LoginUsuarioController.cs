using Clima.Application.Commands.Objects;
using Clima.Application.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Clima.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginUsuarioController : ControllerBase
    {
        private ServicioLoginUsuario Service { get; set; }
        private readonly ILogger<LoginUsuarioController> _logger;

        public LoginUsuarioController(ServicioLoginUsuario service, ILogger<LoginUsuarioController> logger)
        {
            Service = service;
            _logger = logger;
        }

        [Microsoft.AspNetCore.Mvc.HttpPost(Name = "LoginUsuario")]
        public IActionResult Post([FromBody] LoginUserCommandObject commandObject)
        {
            try
            {
                var user = Service.LogUsuario(commandObject);

                if (user.Nombre == null) return BadRequest(new { message = "Mail o password incorrectos" });

                _logger.LogDebug($"Request LoginUsuario, Mail: {commandObject.Mail}");

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(new { message = "Ocurrió un error al intentar loguear al usuario." });
            }
        }
    }
}
