using MidiaSocialEmpresa.Dominio.Entidades;
using MidiaSocialEmpresa.Dominio.Interfaces.Repositorios;
using System.Collections.Generic;
using System.Linq;

namespace MidiaSocialEmpresa.Infra.Data.Repositorios
{
    public class RepositorioProfissional : RepositorioBase<Profissional>, IRepositorioProfissional
    {
        public IEnumerable<Profissional> PesquisaPorNome(string nome)
        {
            return BD.Profissional.Where(a => a.Nome.Contains(nome)).ToList();
        }
    }
}
