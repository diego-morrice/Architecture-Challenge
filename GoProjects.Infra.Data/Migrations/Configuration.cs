namespace GoProjects.Infra.Data.Migrations
{
    using Dominio.Entidades;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    internal sealed class Configuration : DbMigrationsConfiguration<Contexto.MidiaSocialEmpresaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Contexto.MidiaSocialEmpresaContext context)
        {
            //context.Usuario.AddOrUpdate(p => p.Id,
            //new Usuario { Nome = "wkm", Email = "wkm@wkm.com.br", Senha = "wkm123", DataCriacao = DateTime.Now });
            //context.SaveChanges();

            //context.Empresa.AddOrUpdate(p => p.Id,
            //    new Empresa { Nome = "WKM", Usuario = new Usuario { Nome = "wkm", Email = "wkm@wkm.com.br", Senha = "wkm123", DataCriacao = DateTime.Now }, Ativo = true });
            context.SaveChanges();
        }
    }
}
