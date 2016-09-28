using MidiaSocial.Utilidades;
using System;
using System.Collections.Generic;

namespace GoProjects.Dominio.Entidades
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public UsuarioTipo Tipo { get; private set; }
        public string Telefone { get; private set; }
        public string Celular { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public virtual List<Empresa> Empresas { get; private set; }
        public virtual List<Projeto> Projetos { get; private set; }

        public Usuario(string email, string senha, string confirmarSenha, UsuarioTipo tipo)
        {
            ValidacaoPrincipal();

            Email = email;
            Senha = senha;
            Tipo = tipo;
        }

        public Usuario(string nome, string email, string senha, string confirmarSenha, UsuarioTipo tipo, string telefone, string celular)
        {
            ValidacaoPrincipal();

            Nome = nome;
            Email = email;
            Senha = senha;
            Telefone = telefone;
            Celular = celular;
            Tipo = tipo;
        }


        public void Alterar(string nome, string telefone, string celular)
        {
            Nome = nome;
            Telefone = telefone;
            Celular = celular;

            ValidarTamanhoNome();
        }

        public void AlterarSenha(string senhaAtual, string novaSenha, string confirmarNovaSenha)
        {
            if (Senha != senhaAtual)
                throw new Exception("Senha atual inválida.");

            if (novaSenha != confirmarNovaSenha)
                throw new Exception("As senha fornecidas não conferem.");

            Senha = novaSenha;

            ValidarTamanhoSenha();
        }

        //ALTERAR TIPO DE USUÁRIO PRECISA CONFERIAR AUTORIZAÇÃO E MANTERA HISTÓRICO
        //public void AlterarTipoUsuario(UsuarioTipo tipo)
        //{
        //    Tipo = tipo;
        //}

        //EM TERMOS DE NEGÓCIO NÃO FAZ MAIS SENTIDO ESSAS PROPIEDADES SEREM ACESSADAS POR ESSA
        //ENTIDADE DIRETAMENTE
        //public virtual List<Profissional> Profissionais { get; set; }


        internal void ValidarAtualizarUsuario()
        {
            Guardiao.ValidarId(this.Id, "Código de identificação inválido.");
            ValidarSenha();
            ValidarNome();
            Guardiao.ValidarEmail(Email, "Email inválido");
        }
        private void ValidacaoPrincipal()
        {
            ValidarSenha();
            Guardiao.ValidarEmail(Email, "Email inválido");
        }
        private void ValidarSenha()
        {
            Guardiao.ValidarNullOuVazioMensagemPadrao(this.Senha, "Senha");
            ValidarTamanhoSenha();
        }
        private void ValidarNome()
        {
            Guardiao.ValidarNullOuVazioMensagemPadrao(this.Nome, "Nome");
            ValidarTamanhoNome();
        }
        private void ValidarTamanhoNome()
        {
            Guardiao.ValidarTamanhoString("Nome", this.Nome, 3, 150);
        }
        private void ValidarTamanhoSenha()
        {
            Guardiao.ValidarTamanhoString("Senha", this.Senha, 6, 16);
        }
    }
}
