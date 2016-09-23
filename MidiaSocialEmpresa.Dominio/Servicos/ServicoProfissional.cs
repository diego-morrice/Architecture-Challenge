
using MidiaSocialEmpresa.Dominio.Entidades;
using MidiaSocialEmpresa.Dominio.Interfaces.Repositorios;
using MidiaSocialEmpresa.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace MidiaSocialEmpresa.Dominio.Servicos
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
