using System;
using System.Collections.Generic;

namespace GoProjects.Dominio.Entidades
{
    public class Profissional
    {
        public int Id { get; set; }
        public Guid IdUsuario { get; set; }
        public int IdEmpresa { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual List<Atividade> Atividades { get; set; }

        public string Status { get { return this.Ativo == true ? "Ativo" : "Inativo"; } }
        public string DataCriacaoFormatada { get { return this.DataCriacao.ToLongDateString(); } }

    }
}
