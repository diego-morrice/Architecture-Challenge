using MidiaSocialEmpresa.Dominio.Entidades;
using MidiaSocialEmpresa.Dominio.Interfaces.Repositorios;
using System;
using System.Data.Entity;
using System.Linq;

namespace MidiaSocialEmpresa.Infra.Data.Repositorios
{
    public class RepositorioUsuario : RepositorioBase<Usuario>, IRepositorioUsuario
    {
        public bool ValidarEmailJaCadastrado(Usuario usuario)
        {
            if (usuario.Id > 0)
                return BD.Usuario.Any(a => a.Email == usuario.Email && a.Id != usuario.Id);
            else
                return BD.Usuario.Any(a => a.Email == usuario.Email && a.Id != usuario.Id);
        }

        public Usuario CriarUsuario(Usuario usuario)
        {
            if (ValidarEmailJaCadastrado(usuario))
                throw new Exception("Já existe um usuário associado à este email.");

            var entidade = BD.Usuario.Add(usuario);
            BD.SaveChanges();
            return entidade;
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            if (ValidarEmailJaCadastrado(usuario))
                throw new Exception("Já existe um usuário associado à este email.");

            BD.Entry(usuario).State = EntityState.Modified;
            BD.SaveChanges();
        }
    }
}
