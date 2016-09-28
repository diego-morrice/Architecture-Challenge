
using GoProjects.Dominio.Entidades;
using GoProjects.Dominio.Interfaces.Repositorios;
using GoProjects.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace GoProjects.Dominio.Servicos
{
    public class ServicoProfissional : ServicoBase<Profissional>, IServicoProfissional
    {
        private readonly IRepositorioProfissional _repositorioProfissional;

        public ServicoProfissional(IRepositorioProfissional repositorioProfissional)
          : base(repositorioProfissional)
        {
            _repositorioProfissional = repositorioProfissional;
        }

        public IEnumerable<Profissional> PesquisaPorNome(string nome)
        {
            return _repositorioProfissional.PesquisaPorNome(nome);
        }
    }
}
