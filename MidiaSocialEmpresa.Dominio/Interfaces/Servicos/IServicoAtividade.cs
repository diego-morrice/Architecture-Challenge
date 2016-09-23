using MidiaSocialEmpresa.Dominio.Entidades;
using System.Collections.Generic;

namespace MidiaSocialEmpresa.Dominio.Interfaces.Servicos
{
    public interface IServicoAtividade : IServicoBase<Atividade>
    {
        IEnumerable<Atividade> PesquisaPorNome(string nome);
    }
}
