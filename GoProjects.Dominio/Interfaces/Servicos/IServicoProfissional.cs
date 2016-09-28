using GoProjects.Dominio.Entidades;
using System.Collections.Generic;

namespace GoProjects.Dominio.Interfaces.Servicos
{
    public interface IServicoProfissional : IServicoBase<Profissional>
    {
        IEnumerable<Profissional> PesquisaPorNome(string nome);
    }
}