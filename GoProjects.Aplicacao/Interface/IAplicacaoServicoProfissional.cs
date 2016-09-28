using System.Collections.Generic;
using GoProjects.Dominio.Entidades;

namespace GoProjects.Aplicacao.Interface
{
    public interface IAplicacaoServicoProfissional : IAplicacaoServicoBase<Profissional>
    {
        IEnumerable<Profissional> PesquisaPorNome(string texto);
    }
}
