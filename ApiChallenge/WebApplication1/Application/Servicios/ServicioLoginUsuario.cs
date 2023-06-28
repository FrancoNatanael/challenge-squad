using Clima.Application.Commands.Objects;
using Clima.Application.DTO;
using Clima.Domain.Entidades;
using Clima.Domain.Helper;

namespace Clima.Application.Servicios
{
    public class ServicioLoginUsuario
    {
        private HelperLogin HelperConsulta;

        public ServicioLoginUsuario(HelperLogin helperConsulta)
        {
            HelperConsulta = helperConsulta;
        }

        public LoginUsuarioReadModel LogUsuario(LoginUserCommandObject commandObject)
        {
            Usuario usuario = HelperConsulta.ValidarUsuario(commandObject.Mail, commandObject.Password);
            LoginUsuarioReadModel responseLogin = new();

            if (usuario != null)
            {
                responseLogin.Nombre = usuario.Nombre;
                responseLogin.Token = Guid.NewGuid().ToString();
            }

            return responseLogin;
        }
    }
}
