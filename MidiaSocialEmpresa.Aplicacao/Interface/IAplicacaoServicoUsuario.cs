using MidiaSocialEmpresa.Dominio.Entidades;

namespace MidiaSocialEmpresa.Aplicacao.Interface
{
    public interface IAplicacaoServicoUsuario : IAplicacaoServicoBase<Usuario>
    {
        Usuario CriarUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);
    }
}
