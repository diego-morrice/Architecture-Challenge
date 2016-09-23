using MidiaSocialEmpresa.Dominio.Entidades;
using System.Collections.Generic;

namespace MidiaSocialEmpresa.Dominio.Interfaces.Servicos
{
    public interface IServicoProfissional : IServicoBase<Profissional>
    {
        IEnumerable<Profissional> PesquisaPorNome(string nome);
    }
}