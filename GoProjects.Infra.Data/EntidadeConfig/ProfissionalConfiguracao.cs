using GoProjects.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace GoProjects.Infra.Data.EntidadeConfig
{
    public class ProfissionalConfiguracao : EntityTypeConfiguration<Profissional>
    {
        public ProfissionalConfiguracao()
        {
            HasKey(a => a.Id);

            Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Ignore(a => a.Status);
            Ignore(a => a.DataCriacaoFormatada);            

            //HasRequired(a => a.Usuario).WithMany(a => a.Profissionais).HasForeignKey(a => a.IdUsuario);
            HasRequired(a => a.Empresa).WithMany(a => a.Profissionais).HasForeignKey(a => a.IdEmpresa); 
            HasMany(a => a.Atividades).WithOptional(a => a.Profissional);

        }
    }
}
