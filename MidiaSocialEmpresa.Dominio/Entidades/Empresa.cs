using System;
using System.Collections.Generic;

namespace MidiaSocialEmpresa.Dominio.Entidades
{
    public class Empresa
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual List<Profissional> Profissionais { get; set; }

        public string Status { get { return this.Ativo == true ? "Ativo" : "Inativo"; } }
        

    }
}
