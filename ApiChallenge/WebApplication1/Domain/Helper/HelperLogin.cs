using Clima.Domain.Entidades;
using Clima.Domain.Repositorio;

namespace Clima.Domain.Helper
{
    public class HelperLogin
    {
        private IRepositorioUsuario Repositorio { get; set; }
        public HelperLogin(IRepositorioUsuario repositorio)
        {
            Repositorio = repositorio;
        }

        public Usuario ValidarUsuario(string mail, string password)
        {
            return Repositorio.ValidarUsuario(mail, password);

        }
    }
}
