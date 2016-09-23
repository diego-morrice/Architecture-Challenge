using MidiaSocialEmpresa.Aplicacao.Interface;
using MidiaSocialEmpresa.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace MidiaSocialEmpresa.API.Controllers
{
    [RoutePrefix("api/atividade")]
    public class AtividadeController : ApiController
    {

        private readonly IAplicacaoServicoAtividade _aplicacaoAtividade;

        public AtividadeController(IAplicacaoServicoAtividade aplicacaoAtividade)
        {
            _aplicacaoAtividade = aplicacaoAtividade;
        }

        [HttpGet]
        //[Authorize(Roles = "Empresa")]
        //[Authorize(Roles = "Usuario")]
        [Authorize(Roles = "User")]
        public IEnumerable<Atividade> RetornarTodas()
        {
            return _aplicacaoAtividade.RetornarTodos();
        }

        [HttpGet]
        //[Authorize(Roles = "Empresa")]
        //[Authorize(Roles = "Usuario")]
        [Authorize(Roles = "User")]
        public Atividade RetornarAtividade(int id)
        {
            return _aplicacaoAtividade.RetornaPorId(id);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IEnumerable<Atividade> RetornarAtividadePorNome(string texto)
        {
            return _aplicacaoAtividade.PesquisaPorNome(texto);
        }


        [HttpPost]
        //[Authorize(Roles = "Empresa")]
        //[Authorize(Roles = "Usuario")]
        [Authorize(Roles = "User")]
        public HttpResponseMessage Nova(Atividade atividade)
        {
            try
            {                
                _aplicacaoAtividade.Adicionar(atividade);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPatch]
        //[Authorize(Roles = "Empresa")]
        //[Authorize(Roles = "Usuario")]
        [Authorize(Roles = "User")]
        public HttpResponseMessage Atualizar(Atividade atividade)
        {
            try
            {
                _aplicacaoAtividade.Atualizar(atividade);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpDelete]
        //[Authorize(Roles = "Empresa")]
        //[Authorize(Roles = "Usuario")]
        [Authorize(Roles = "User")]
        public HttpResponseMessage Inativar(int id)
        {
            try
            {
                var ativividade = _aplicacaoAtividade.RetornaPorId(id);
                ativividade.Ativa = false;

                if (ativividade == null)
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);

                _aplicacaoAtividade.Atualizar(ativividade);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}