using GoProjects.Dominio.Entidades;
using System.Collections.Generic;

namespace GoProjects.Aplicacao.Interface
{
    public interface IAplicacaoServicoAtividade : IAplicacaoServicoBase<Atividade>
    {
        IEnumerable<Atividade> PesquisaPorNome(string nome);
    }
}
