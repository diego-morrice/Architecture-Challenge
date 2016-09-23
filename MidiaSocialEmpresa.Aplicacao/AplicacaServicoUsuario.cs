
using System;
using MidiaSocialEmpresa.Aplicacao.Interface;
using MidiaSocialEmpresa.Dominio.Entidades;
using MidiaSocialEmpresa.Dominio.Interfaces.Servicos;

namespace MidiaSocialEmpresa.Aplicacao
{
    public class AplicacaoServicoUsuario : AplicacaoServicoBase<Usuario>, IAplicacaoServicoUsuario
    {
        private readonly IServicoUsuario _servicoUsuario;

        public AplicacaoServicoUsuario(IServicoUsuario servicoUsuario)
            : base(servicoUsuario)
        {
            _servicoUsuario = servicoUsuario;
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            _servicoUsuario.AtualizarUsuario(usuario);
        }

        public Usuario CriarUsuario(Usuario usuario)
        {
            return _servicoUsuario.CriarUsuario(usuario);
        }

    }
}
