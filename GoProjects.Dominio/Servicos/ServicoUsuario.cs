
using GoProjects.Dominio.Entidades;
using GoProjects.Dominio.Interfaces.Repositorios;
using GoProjects.Dominio.Interfaces.Servicos;

namespace GoProjects.Dominio.Servicos
{
    public class ServicoUsuario : ServicoBase<Usuario>, IServicoUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public ServicoUsuario(IRepositorioUsuario repositorioUsuario)
            : base(repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public Usuario CriarUsuario(Usuario usuario)
        {            
            return _repositorioUsuario.CriarUsuario(usuario);
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            usuario.ValidarAtualizarUsuario();
            _repositorioUsuario.CriarUsuario(usuario);
        }
    }
}
