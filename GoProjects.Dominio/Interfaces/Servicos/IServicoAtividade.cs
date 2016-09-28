using GoProjects.Dominio.Entidades;
using System.Collections.Generic;

namespace GoProjects.Dominio.Interfaces.Servicos
{
    public interface IServicoAtividade : IServicoBase<Atividade>
    {
        IEnumerable<Atividade> PesquisaPorNome(string nome);
    }
}
