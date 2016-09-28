using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GoProjects.Dominio.Entidades;

namespace GoProjects.Infra.DadosTest
{

    public class UsuarioTesteDados
    {
        public static List<Usuario> Retornar()
        {
            return new List<Usuario>
            {
               new Usuario ("usuario1@mail.com", "123456", "123456", new UsuarioTipo()) { },
               new Usuario ("usuario2@mail.com", "123456", "123456", new UsuarioTipo()) { },
               new Usuario ("usuario3@mail.com", "123456", "123456", new UsuarioTipo()) { },
               new Usuario ("usuario4@mail.com", "123456", "123456", new UsuarioTipo()) { }

            };
        }
    }
}
