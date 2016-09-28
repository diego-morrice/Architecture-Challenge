using System.Collections.Generic;
using GoProjects.Dominio.Entidades;

namespace GoProjects.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioProjeto : IRepositorioBase<Projeto>
    {
        IEnumerable<Projeto> PesquisaPorNome(string nome);
        bool ValidarNomeJaCadastrado(Projeto usuario);
        Projeto CriarProjeto(Projeto usuario);
        void AtualizarProjeto(Projeto usuario);
    }
}
