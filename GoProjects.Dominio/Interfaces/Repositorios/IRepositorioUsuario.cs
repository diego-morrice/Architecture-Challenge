using GoProjects.Dominio.Entidades;

namespace GoProjects.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioUsuario : IRepositorioBase<Usuario>
    {
        bool ValidarEmailJaCadastrado(Usuario usuario);
        Usuario CriarUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);
    }
}
