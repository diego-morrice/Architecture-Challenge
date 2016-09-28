using System;
using System.Collections.Generic;
using GoProjects.Aplicacao.Interface;
using GoProjects.Dominio.Entidades;
using GoProjects.Dominio.Interfaces.Servicos;

namespace GoProjects.Aplicacao
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
