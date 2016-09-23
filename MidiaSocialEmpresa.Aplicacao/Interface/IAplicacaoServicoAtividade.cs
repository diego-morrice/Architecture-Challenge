using MidiaSocialEmpresa.Dominio.Entidades;
using System.Collections.Generic;

namespace MidiaSocialEmpresa.Aplicacao.Interface
{
    public interface IAplicacaoServicoAtividade : IAplicacaoServicoBase<Atividade>
    {
        IEnumerable<Atividade> PesquisaPorNome(string nome);
    }
}
