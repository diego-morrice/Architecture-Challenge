using MidiaSocialEmpresa.Dominio.Entidades;

namespace MidiaSocialEmpresa.Dominio.Interfaces.Servicos
{
    public interface IServicoUsuario : IServicoBase<Usuario>
    {
        Usuario CriarUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);
    }
}