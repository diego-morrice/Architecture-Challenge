using System;
using System.Collections.Generic;
using GoProjects.Dominio.Entidades;
using GoProjects.Dominio.Interfaces.Repositorios;
using GoProjects.Dominio.Interfaces.Servicos;

namespace GoProjects.Dominio.Servicos
{
    public class ServicoAtividade : ServicoBase<Atividade>, IServicoAtividade
    {
        public readonly IRepositorioAtividade _repositorioAtividade;

        public ServicoAtividade(IRepositorioAtividade repositorioAtividade)
            : base(repositorioAtividade)
        {
            _repositorioAtividade = repositorioAtividade;
        }

        public IEnumerable<Atividade> PesquisaPorNome(string nome)
        {
            return _repositorioAtividade.PesquisaPorNome(nome);
        }
    }
}
