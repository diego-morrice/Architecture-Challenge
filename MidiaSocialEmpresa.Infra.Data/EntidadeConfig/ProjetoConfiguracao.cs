
using MidiaSocialEmpresa.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace MidiaSocialEmpresa.Infra.Data.EntidadeConfig
{
    public class ProjetoConfiguracao : EntityTypeConfiguration<Projeto>
    {
        public ProjetoConfiguracao()
        {
            HasKey(a => a.Id);

            Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Ignore(a => a.Status);
            Ignore(a => a.DataCriacaoFormatada);

            HasRequired(a => a.Usuario).WithMany(a => a.Projetos).HasForeignKey(a => a.IdUsuario);
            HasMany(a => a.Atividades).WithRequired(a => a.Projeto);

        }
    }
}
