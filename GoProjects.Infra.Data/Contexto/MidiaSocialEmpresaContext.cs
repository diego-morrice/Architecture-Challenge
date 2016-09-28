using GoProjects.Dominio.Entidades;
using GoProjects.Infra.Data.EntidadeConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace GoProjects.Infra.Data.Contexto
{
    public class MidiaSocialEmpresaContext : DbContext
    {
        public MidiaSocialEmpresaContext()
            : base("MidiaSocialEmpresa")
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Profissional> Profissional { get; set; }
        public DbSet<Atividade> Atividade { get; set; }
        public DbSet<Projeto> Projeto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()               
               .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
               .Configure(p => p.HasMaxLength(100));

            modelBuilder.Properties<string>()
               .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new AtividadeConfiguracao());
            modelBuilder.Configurations.Add(new UsuarioConfiguracao());
            modelBuilder.Configurations.Add(new EmpresaConfiguracao());
            modelBuilder.Configurations.Add(new ProfissionalConfiguracao());
            modelBuilder.Configurations.Add(new ProjetoConfiguracao());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCriacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCriacao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCriacao").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Ativo") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Ativo").CurrentValue = false;
                }              
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Ativa") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Ativa").CurrentValue = false;
                }             
            }

            return base.SaveChanges();
        }
    }
}
