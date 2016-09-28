using GoProjects.Aplicacao.Interface;
using GoProjects.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace GoProjects.API.Controllers
{
    [RoutePrefix("api/projeto")]
    public class ProjetoController : ApiController
    {

        private readonly IAplicacaoServicoProjeto _aplicacaoProjeto;

        public ProjetoController(IAplicacaoServicoProjeto aplicacaoProjeto)
        {
            _aplicacaoProjeto = aplicacaoProjeto;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IEnumerable<Projeto> RetornarTodos()
        {
            return _aplicacaoProjeto.RetornarTodos();
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public Projeto RetornarProjeto(int id)
        {
            return _aplicacaoProjeto.RetornaPorId(id);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IEnumerable<Projeto> RetornarProjetoPorNome(string texto)
        {
            return _aplicacaoProjeto.PesquisaPorNome(texto);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public HttpResponseMessage Novo(Projeto projeto)
        {
            try
            {
                projeto.IdUsuario = int.Parse(User.Identity.Name);
                _aplicacaoProjeto.CriarProjeto(projeto);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPatch]
        [Authorize(Roles = "User")]
        public HttpResponseMessage Atualizar(Projeto projeto)
        {
            try
            {
                projeto.IdUsuario = int.Parse(User.Identity.Name);
                _aplicacaoProjeto.AtualizarProjeto(projeto);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpDelete]
        [Authorize(Roles = "User")]
        public HttpResponseMessage Inativar(int id)
        {
            try
            {
                var projeto = _aplicacaoProjeto.RetornaPorId(id);
                projeto.Ativo = false;

                if (projeto == null)
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);

                _aplicacaoProjeto.Atualizar(projeto);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}