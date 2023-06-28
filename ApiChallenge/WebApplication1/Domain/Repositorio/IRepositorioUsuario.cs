using Clima.Domain.Entidades;

namespace Clima.Domain.Repositorio
{
    public interface IRepositorioUsuario
    {
        public Usuario ValidarUsuario(string mail, string password);
    }
}
