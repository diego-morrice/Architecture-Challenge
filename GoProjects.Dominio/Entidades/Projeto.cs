using MidiaSocial.Utilidades;
using System;
using System.Collections.Generic;

namespace GoProjects.Dominio.Entidades
{
    public class Projeto
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual List<Atividade> Atividades { get; set; }

        public string Status { get { return this.Ativo == true ? "Ativo" : "Inativo"; } }

        public string DataCriacaoFormatada { get { return this.DataCriacao.ToLongDateString(); } }

        internal void ValidarAtualizarProjeto()
        {
            ValidarId();
            ValidarNome();
        }

        public void ValidarCriarProjeto()
        {
            ValidarNome();
        }

        private void ValidarId()
        {
            Guardiao.ValidarId(this.Id, "Código de identificação do projeto inválido.");
        }

        private void ValidarNome()
        {
            Guardiao.ValidarNullOuVazioMensagemPadrao(this.Nome, "Nome");   
            this.ValidarTamanhoNome();
        }

        private void ValidarTamanhoNome()
        {
            Guardiao.ValidarTamanhoString("Nome", this.Nome, 3, 150);
        }
    }
}
