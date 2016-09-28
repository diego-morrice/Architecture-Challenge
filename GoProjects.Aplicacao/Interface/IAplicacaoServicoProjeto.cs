
using System.Collections.Generic;
using GoProjects.Dominio.Entidades;

namespace GoProjects.Aplicacao.Interface
{
    public interface IAplicacaoServicoProjeto : IAplicacaoServicoBase<Projeto>
    {
        IEnumerable<Projeto> PesquisaPorNome(string texto);
        Projeto CriarProjeto(Projeto projeto);
        void AtualizarProjeto(Projeto projeto);
    }
}
