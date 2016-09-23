using System.Collections.Generic;
using MidiaSocialEmpresa.Dominio.Entidades;

namespace MidiaSocialEmpresa.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioProfissional : IRepositorioBase<Profissional>
    {
        IEnumerable<Profissional> PesquisaPorNome(string nome);
    }
}
