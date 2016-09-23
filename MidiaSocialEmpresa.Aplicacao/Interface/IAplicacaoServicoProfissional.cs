using System.Collections.Generic;
using MidiaSocialEmpresa.Dominio.Entidades;

namespace MidiaSocialEmpresa.Aplicacao.Interface
{
    public interface IAplicacaoServicoProfissional : IAplicacaoServicoBase<Profissional>
    {
        IEnumerable<Profissional> PesquisaPorNome(string texto);
    }
}
