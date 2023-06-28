using Clima.Application.Commands.Objects;
using Clima.Application.Servicios;
using Clima.Domain.Helper;
using Clima.Infrastructure.Context;
using Clima.Infrastructure.RepositorioEF;

namespace Tests
{
    public class TestLogin
    {
        [Fact]
        public void PruebaLogUsuario_QueSePuedaLoguearYValidarUnUsuario()
        {
            //Arrange
            ClimaContexto contexto = new();
            HelperLogin Helper = new(new UsuarioRepositorio());
            ServicioLoginUsuario Service = new ServicioLoginUsuario(Helper);
            LoginUserCommandObject userData = new LoginUserCommandObject()
            {
                Mail = "usuario@gmail.com",
                Password = "999"
            };

            //Act
            contexto.InsertData();
            var usuario = Service.LogUsuario(userData);

            //Assert
            Assert.NotNull(usuario.Nombre);
        }

        [Fact]
        public void PruebaLogUsuario_QueNoSePuedaLoguearYValidarUnUsuario()
        {
            //Arrange
            ClimaContexto contexto = new();
            HelperLogin Helper = new(new UsuarioRepositorio());
            ServicioLoginUsuario Service = new ServicioLoginUsuario(Helper);
            LoginUserCommandObject userData = new LoginUserCommandObject()
            {
                Mail = "USUARIO@gmail.com",
                Password = "1234454"
            };

            //Act
            contexto.InsertData();
            var usuario = Service.LogUsuario(userData);

            //Assert
            Assert.Null(usuario.Nombre);
        }
    }
}
