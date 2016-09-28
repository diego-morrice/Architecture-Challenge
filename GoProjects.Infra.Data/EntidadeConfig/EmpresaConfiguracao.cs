using GoProjects.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace GoProjects.Infra.Data.EntidadeConfig
{
    public class EmpresaConfiguracao : EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfiguracao()
        {
            HasKey(a => a.Id);

            Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Ignore(a => a.Status);            

            HasRequired(a => a.Usuario).WithMany(a => a.Empresas).HasForeignKey(a => a.IdUsuario);
            HasMany(a => a.Profissionais);
        }
    }
}
