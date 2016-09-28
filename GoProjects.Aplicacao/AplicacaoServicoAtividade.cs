
using GoProjects.Aplicacao.Interface;
using GoProjects.Dominio.Entidades;
using GoProjects.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace GoProjects.Aplicacao
{
    public class AplicacaoServicoAtividade : AplicacaoServicoBase<Atividade>, IAplicacaoServicoAtividade
    {
        private readonly IServicoAtividade _servicoAtividade;

        public AplicacaoServicoAtividade(IServicoAtividade servicoAtividade)
            : base(servicoAtividade)
        {
            _servicoAtividade = servicoAtividade;
        }

        public IEnumerable<Atividade> PesquisaPorNome(string nome)
        {
            return _servicoAtividade.PesquisaPorNome(nome);
        }
    }
}
