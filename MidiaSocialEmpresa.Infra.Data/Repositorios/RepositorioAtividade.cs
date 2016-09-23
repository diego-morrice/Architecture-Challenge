using System.Collections.Generic;
using MidiaSocialEmpresa.Dominio.Entidades;
using MidiaSocialEmpresa.Dominio.Interfaces.Repositorios;
using System.Linq;

namespace MidiaSocialEmpresa.Infra.Data.Repositorios
{
    public class RepositorioAtividade : RepositorioBase<Atividade>, IRepositorioAtividade
    {
        public IEnumerable<Atividade> PesquisaPorNome(string nome)
        {
            return BD.Atividade.Where(a => a.Nome.Contains(nome)).ToList();
        }
    }
}
