using Microsoft.Owin.Security.OAuth;
using GoProjects.Dominio.Entidades;
using GoProjects.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace GoProjects.API
{
    public class Autorizador : OAuthAuthorizationServerProvider
    {
        private readonly IServicoUsuario _servicoUsuario;

        public Autorizador(IServicoUsuario servicoUsuario)
        {
            _servicoUsuario = servicoUsuario;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

                Usuario usuario = _servicoUsuario.RetornaPorExpressao(el => el.Nome == context.UserName && el.Senha == context.Password);
                if (usuario == null)
                {
                    context.SetError("Acesso negado.", "Usuário ou Senha inválidos.");
                    return;
                }               

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, usuario.Id.ToString()));                

                //if (usuario.Empresa != null) identity.AddClaim(new Claim(ClaimTypes.Role, "Empresa"));                

                //if (usuario.Profissional != null)  identity.AddClaim(new Claim(ClaimTypes.Role, "Profissional"));
                

                var roles = new List<string>();
                roles.Add("User");

                foreach (var item in roles)
                    identity.AddClaim(new Claim(ClaimTypes.Role, item));

                GenericPrincipal principal = new GenericPrincipal(identity, roles.ToArray());
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }
            catch (Exception ex)
            {
                context.SetError("Acesso negado.", ex.Message);
                return;
            }
        }
    }
}