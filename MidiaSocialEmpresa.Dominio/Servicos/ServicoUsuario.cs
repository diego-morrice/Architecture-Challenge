
using MidiaSocialEmpresa.Dominio.Entidades;
using MidiaSocialEmpresa.Dominio.Interfaces.Repositorios;
using MidiaSocialEmpresa.Dominio.Interfaces.Servicos;

namespace MidiaSocialEmpresa.Dominio.Servicos
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
            usuario.ValidarCriarUsuario();
            return _repositorioUsuario.CriarUsuario(usuario);
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            usuario.ValidarAtualizarUsuario();
            _repositorioUsuario.CriarUsuario(usuario);
        }
    }
}
