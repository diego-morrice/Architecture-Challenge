using GoProjects.Dominio.Entidades;

namespace GoProjects.Dominio.Interfaces.Servicos
{
    public interface IServicoUsuario : IServicoBase<Usuario>
    {
        Usuario CriarUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);
    }
}