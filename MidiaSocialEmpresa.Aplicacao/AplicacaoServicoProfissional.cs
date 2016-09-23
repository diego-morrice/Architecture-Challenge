using System;
using System.Collections.Generic;
using MidiaSocialEmpresa.Aplicacao.Interface;
using MidiaSocialEmpresa.Dominio.Entidades;
using MidiaSocialEmpresa.Dominio.Interfaces.Servicos;

namespace MidiaSocialEmpresa.Aplicacao
{
    public class AplicacaoServicoProfissional : AplicacaoServicoBase<Profissional>, IAplicacaoServicoProfissional
    {
        private readonly IServicoProfissional _servicoProfissional;

        public AplicacaoServicoProfissional(IServicoProfissional servicoProfissional)
            : base(servicoProfissional)
        {
            _servicoProfissional = servicoProfissional;
        }

        public IEnumerable<Profissional> PesquisaPorNome(string texto)
        {
            return _servicoProfissional.PesquisaPorNome(texto);
        }
    }
}
