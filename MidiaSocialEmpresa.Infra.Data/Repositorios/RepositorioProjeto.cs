using MidiaSocialEmpresa.Dominio.Entidades;
using MidiaSocialEmpresa.Dominio.Interfaces.Repositorios;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.Entity;

namespace MidiaSocialEmpresa.Infra.Data.Repositorios
{
    public class RepositorioProjeto : RepositorioBase<Projeto>, IRepositorioProjeto
    {
        public void AtualizarProjeto(Projeto projeto)
        {
            if (ValidarNomeJaCadastrado(projeto))
                throw new Exception("Um projeto com esse nome já foi cadastrado.");

            BD.Entry(projeto).State = EntityState.Modified;
            BD.SaveChanges();
        }

        public Projeto CriarProjeto(Projeto projeto)
        {
            if (ValidarNomeJaCadastrado(projeto))
                throw new Exception("Um projeto com esse nome já foi cadastrado.");

            var entidade = BD.Projeto.Add(projeto);
            BD.SaveChanges();
            return entidade;
        }

        public IEnumerable<Projeto> PesquisaPorNome(string nome)
        {
            return BD.Projeto.Where(a => a.Nome.Contains(nome)).ToList();
        }

        public bool ValidarNomeJaCadastrado(Projeto projeto)
        {
            if (projeto.Id > 0)
                return BD.Projeto.Any(a => a.Nome == projeto.Nome && a.Id != projeto.Id);

            return BD.Projeto.Any(a => a.Nome == projeto.Nome);
        }
    }
}
