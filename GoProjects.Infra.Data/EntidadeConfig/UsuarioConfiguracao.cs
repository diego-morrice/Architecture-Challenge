using GoProjects.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace GoProjects.Infra.Data.EntidadeConfig
{
    public class UsuarioConfiguracao : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguracao()
        {
            HasKey(a => a.Id);

            Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(a => a.Email)
                .HasMaxLength(35)
                .IsRequired();

            Property(a => a.Senha)
                .HasMaxLength(16)
                .IsRequired();

            HasMany(a => a.Projetos).WithRequired(a => a.Usuario);
            HasMany(a => a.Empresas).WithRequired(a => a.Usuario);
            //HasMany(a => a.Profissionais).WithRequired(a => a.Usuario);
        }
    }
}
