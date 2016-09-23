using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class AtividadeViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Nome { get; set; }

        public int IdProfissional { get; set; }

        public int IdProjeto { get; set; }

        public bool Ativa { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCriacao { get; set; }
        [DisplayName("Início")]
        public DateTime DataInicio { get; set; }
        [DisplayName("Término")]
        public DateTime DataFim { get; set; }
        public ProfissionalViewModel Profissional { get; set; }
        public ProjetoViewModel Projeto { get; set; }



    }
}