using Clima.Domain.Entidades;
using Clima.Domain.Repositorio;
using Clima.Infrastructure.Context;

namespace Clima.Infrastructure.RepositorioEF
{
    public class UsuarioRepositorio : IRepositorioUsuario
    {
        public UsuarioRepositorio()
        {
        }

        public Usuario ValidarUsuario(string mail, string password)
        {
            using (var Contexto = new ClimaContexto())
            {
                var usuario = from usuarioObj in Contexto.Usuario
                              where usuarioObj.Mail == mail && usuarioObj.Password == password
                              select new Usuario
                              {
                                  Id = usuarioObj.Id,
                                  Nombre = usuarioObj.Nombre,
                                  Password = usuarioObj.Password,
                                  Mail = usuarioObj.Mail
                              };

                return usuario.ToList().FirstOrDefault();
            }

        }
    }
}
