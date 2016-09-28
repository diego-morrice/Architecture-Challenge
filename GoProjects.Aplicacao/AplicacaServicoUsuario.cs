
using System;
using GoProjects.Aplicacao.Interface;
using GoProjects.Dominio.Entidades;
using GoProjects.Dominio.Interfaces.Servicos;

namespace GoProjects.Aplicacao
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
