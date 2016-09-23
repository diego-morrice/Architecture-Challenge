using MidiaSocialEmpresa.Dominio.Entidades;
using System.Collections.Generic;

namespace MidiaSocialEmpresa.Dominio.Interfaces.Servicos
{
    public interface IServicoProjeto : IServicoBase<Projeto>
    {
        IEnumerable<Projeto> PesquisaPorNome(string nome);
        void AtualizarProjeto(Projeto projeto);
        Projeto CriarProjeto(Projeto projeto);
    }
}