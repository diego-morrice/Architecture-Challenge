using MidiaSocialEmpresa.Dominio.Entidades;
using System.Collections.Generic;

namespace MidiaSocialEmpresa.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioAtividade : IRepositorioBase<Atividade>
    {
        IEnumerable<Atividade> PesquisaPorNome(string nome);
    }
}
