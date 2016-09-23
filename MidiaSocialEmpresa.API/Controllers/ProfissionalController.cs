using MidiaSocialEmpresa.Aplicacao.Interface;
using MidiaSocialEmpresa.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace MidiaSocialEmpresa.API.Controllers
{
    [RoutePrefix("api/profissional")]
    public class ProfissionalController : ApiController
    {

        private readonly IAplicacaoServicoProfissional _aplicacaoProfissional;
        private readonly IAplicacaoServicoUsuario _aplicacaoUsuario;

        public ProfissionalController(IAplicacaoServicoProfissional aplicacaoProfissional, IAplicacaoServicoUsuario aplicacaoUsuario)
        {
            _aplicacaoProfissional = aplicacaoProfissional;
            _aplicacaoUsuario = aplicacaoUsuario;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IEnumerable<Profissional> RetornarTodos()
        {
            return _aplicacaoProfissional.RetornarTodos();
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public Profissional RetornarProfissional(int id)
        {
            return _aplicacaoProfissional.RetornaPorId(id);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IEnumerable<Profissional> RetornarProfissionalPorNome(string texto)
        {
            return _aplicacaoProfissional.PesquisaPorNome(texto);
        }



        [HttpPost]
        [Authorize(Roles = "User")]
        public HttpResponseMessage Novo(Profissional profissional)
        {
            try
            {
                var usuario = _aplicacaoUsuario.CriarUsuario(profissional.Usuario);
                profissional.IdEmpresa = int.Parse(User.Identity.Name);
                profissional.IdUsuario = usuario.Id;
                _aplicacaoProfissional.Adicionar(profissional);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }            
        }


        [HttpPatch]
        [Authorize(Roles = "User")]
        public HttpResponseMessage Atualizar(Profissional profissional)
        {
            try
            {
                 _aplicacaoUsuario.AtualizarUsuario(profissional.Usuario);
                _aplicacaoProfissional.Atualizar(profissional);
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
                var profissional = _aplicacaoProfissional.RetornaPorId(id);
                profissional.Ativo = false;

                if (profissional == null)
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);

                _aplicacaoProfissional.Atualizar(profissional);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}