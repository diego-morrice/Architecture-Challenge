using System.Collections.Generic;
using GoProjects.Dominio.Entidades;
using GoProjects.Dominio.Interfaces.Repositorios;
using System.Linq;

namespace GoProjects.Infra.Data.Repositorios
{
    public class RepositorioAtividade : RepositorioBase<Atividade>, IRepositorioAtividade
    {
        public IEnumerable<Atividade> PesquisaPorNome(string nome)
        {
            return BD.Atividade.Where(a => a.Nome.Contains(nome)).ToList();
        }
    }
}
