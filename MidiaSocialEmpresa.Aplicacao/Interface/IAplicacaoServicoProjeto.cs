
using System.Collections.Generic;
using MidiaSocialEmpresa.Dominio.Entidades;

namespace MidiaSocialEmpresa.Aplicacao.Interface
{
    public interface IAplicacaoServicoProjeto : IAplicacaoServicoBase<Projeto>
    {
        IEnumerable<Projeto> PesquisaPorNome(string texto);
        Projeto CriarProjeto(Projeto projeto);
        void AtualizarProjeto(Projeto projeto);
    }
}
