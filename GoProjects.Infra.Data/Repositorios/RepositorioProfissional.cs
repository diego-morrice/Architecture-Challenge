using GoProjects.Dominio.Entidades;
using GoProjects.Dominio.Interfaces.Repositorios;
using System.Collections.Generic;
using System.Linq;

namespace GoProjects.Infra.Data.Repositorios
{
    public class RepositorioProfissional : RepositorioBase<Profissional>, IRepositorioProfissional
    {
        public IEnumerable<Profissional> PesquisaPorNome(string nome)
        {
            return BD.Profissional.Where(a => a.Nome.Contains(nome)).ToList();
        }
    }
}
