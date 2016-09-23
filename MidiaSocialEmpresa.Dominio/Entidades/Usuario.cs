
using MidiaSocial.Utilidades;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MidiaSocialEmpresa.Dominio.Entidades
{
    public class Usuario
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }
        public virtual List<Empresa> Empresas { get; set; }
        public virtual List<Profissional> Profissionais { get; set; }
        public virtual List<Projeto> Projetos { get; set; }


        public void ValidarEmail()
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            if (!regexEmail.IsMatch(this.Email))
                throw new Exception("E-mail inválido");

        }

        internal void ValidarAtualizarUsuario()
        {
            ValidarId();
            ValidarSenha();
            ValidarEmail();
            ValidarNome();
        }

        public void ValidarCriarUsuario()
        {            
            ValidarSenha();
            ValidarEmail();
            ValidarNome();          
        }

        private void ValidarSenha()
        {
            Guardiao.ValidarNullOuVazioMensagemPadrao(this.Senha, "Senha");
            this.ValidarTamanhoSenha();
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

        private void ValidarTamanhoSenha()
        {
            Guardiao.ValidarTamanhoString("Senha", this.Senha, 6, 16);
        }
        private void ValidarId()
        {
            Guardiao.ValidarId(this.Id, "Código de identificação inválido.");
        }

    }
}
