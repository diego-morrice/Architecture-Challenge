using System;

namespace GoProjects.Dominio.Entidades
{
    public class Atividade
    {
        public int Id { get; set; }
        public int? IdProfissional { get; set; }
        public int IdProjeto { get; set; }
        public string Nome { get; set; }
        public bool Ativa { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public virtual Profissional Profissional { get; set; }
        public virtual Projeto Projeto { get; set; }
        public string DataInicioFormatada { get { return this.DataInicio.ToLongDateString(); } }
        public string DataFimFormatada { get { return this.DataInicio.ToLongDateString(); } }
        public string Status { get { return this.Ativa == true ? "Ativo" : "Inativo"; } }

    }
}
