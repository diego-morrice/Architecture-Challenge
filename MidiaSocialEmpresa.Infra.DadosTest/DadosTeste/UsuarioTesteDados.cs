using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MidiaSocialEmpresa.Dominio.Entidades;

namespace MidiaSocialEmpresa.Infra.DadosTest
{

    public class UsuarioTesteDados
    {
        public static List<Usuario> Retornar()
        {
            return new List<Usuario>
            {
               new Usuario {Nome="usuario1", Email="usuario1@mail.com", Senha="123456" },
               new Usuario {Nome="usuario2", Email="usuario2@mail.com", Senha="123456" },
               new Usuario {Nome="usuario3", Email="usuario3@mail.com", Senha="123456" },
               new Usuario {Nome="usuario4", Email="usuario4@mail.com", Senha="123456" },
               new Usuario {Nome="usuario5", Email="usuario5@mail.com", Senha="123456" }
            };
        }
    }
}
