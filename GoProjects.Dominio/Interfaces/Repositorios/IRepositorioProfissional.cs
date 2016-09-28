using System.Collections.Generic;
using GoProjects.Dominio.Entidades;

namespace GoProjects.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioProfissional : IRepositorioBase<Profissional>
    {
        IEnumerable<Profissional> PesquisaPorNome(string nome);
    }
}
