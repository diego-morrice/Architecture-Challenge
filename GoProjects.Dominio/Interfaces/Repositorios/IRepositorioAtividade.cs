using GoProjects.Dominio.Entidades;
using System.Collections.Generic;

namespace GoProjects.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioAtividade : IRepositorioBase<Atividade>
    {
        IEnumerable<Atividade> PesquisaPorNome(string nome);
    }
}
