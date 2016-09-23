
using MidiaSocialEmpresa.Dominio.Entidades;
using MidiaSocialEmpresa.Dominio.Interfaces.Repositorios;
using MidiaSocialEmpresa.Dominio.Interfaces.Servicos;
using System.Collections.Generic;
using System;

namespace MidiaSocialEmpresa.Dominio.Servicos
{
    public class ServicoProjeto : ServicoBase<Projeto>, IServicoProjeto
    {
        private readonly IRepositorioProjeto _repositorioProjeto;

        public ServicoProjeto(IRepositorioProjeto repositorioProjeto)
            : base(repositorioProjeto)
        {
            _repositorioProjeto = repositorioProjeto;
        }

        public void AtualizarProjeto(Projeto projeto)
        {
            projeto.ValidarAtualizarProjeto();
            _repositorioProjeto.AtualizarProjeto(projeto);
        }

        public Projeto CriarProjeto(Projeto projeto)
        {
            projeto.ValidarCriarProjeto();
            return _repositorioProjeto.CriarProjeto(projeto);
        }

        public IEnumerable<Projeto> PesquisaPorNome(string nome)
        {
            return _repositorioProjeto.PesquisaPorNome(nome);
        }
    }
}
