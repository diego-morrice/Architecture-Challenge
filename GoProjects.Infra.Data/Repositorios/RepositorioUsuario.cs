using GoProjects.Dominio.Entidades;
using GoProjects.Dominio.Interfaces.Repositorios;
using System;
using System.Data.Entity;
using System.Linq;

namespace GoProjects.Infra.Data.Repositorios
{
    public class RepositorioUsuario : RepositorioBase<Usuario>, IRepositorioUsuario
    {
        public bool ValidarEmailJaCadastrado(Usuario usuario)
        {
            if (usuario.Id != Guid.Empty)
                return BD.Usuario.Any(a => a.Email == usuario.Email && a.Id != usuario.Id);
            else
                return BD.Usuario.Any(a => a.Email == usuario.Email && a.Id != usuario.Id);
        }

        public Usuario CriarUsuario(Usuario usuario)
        {
            var entidade = BD.Usuario.Add(usuario);
            BD.SaveChanges();
            return entidade;
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            BD.Entry(usuario).State = EntityState.Modified;
            BD.SaveChanges();
        }
    }
}
