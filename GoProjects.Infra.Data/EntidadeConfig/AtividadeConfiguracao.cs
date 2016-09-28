using System.Data.Entity.ModelConfiguration;
using GoProjects.Dominio.Entidades;


namespace GoProjects.Infra.Data.EntidadeConfig
{
    public class AtividadeConfiguracao : EntityTypeConfiguration<Atividade>
    {
        public AtividadeConfiguracao()
        {
            HasKey(a => a.Id);

            Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Ignore(a => a.Status);
            Ignore(a => a.DataInicioFormatada);
            Ignore(a => a.DataFimFormatada);

            HasRequired(a => a.Projeto).WithMany(a => a.Atividades).HasForeignKey(a => a.IdProjeto);
            HasOptional(a => a.Profissional).WithMany(a => a.Atividades).HasForeignKey(a => a.IdProfissional);
        }
    }
}
