using GoProjects.Dominio.Entidades;

namespace GoProjects.Aplicacao.Interface
{
    public interface IAplicacaoServicoUsuario : IAplicacaoServicoBase<Usuario>
    {
        Usuario CriarUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);
    }
}
