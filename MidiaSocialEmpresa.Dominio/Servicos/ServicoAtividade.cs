using System;
using System.Collections.Generic;
using MidiaSocialEmpresa.Dominio.Entidades;
using MidiaSocialEmpresa.Dominio.Interfaces.Repositorios;
using MidiaSocialEmpresa.Dominio.Interfaces.Servicos;

namespace MidiaSocialEmpresa.Dominio.Servicos
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
