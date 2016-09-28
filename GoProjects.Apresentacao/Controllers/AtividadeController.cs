using AutoMapper;
using MidiaSocialEmpresa.Aplicacao.Interface;
using MidiaSocialEmpresa.Dominio.Entidades;
using System.Collections.Generic;
using System.Web.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class AtividadeController : Controller
    {

        private readonly IAplicacaoServicoAtividade _aplicacaoAtividade;

        public AtividadeController(IAplicacaoServicoAtividade aplicacaoAtividade)
        {
            _aplicacaoAtividade = aplicacaoAtividade;
        }

        // GET: Atividade
        public ActionResult Index()
        {
            var atividades = Mapper.Map<IEnumerable<Atividade>,
                IEnumerable<AtividadeViewModel>>(_aplicacaoAtividade.RetornarTodos());
            return View(atividades);
        }

        // GET: Atividade/VerAtividade/5
        public ActionResult VerAtividade(int id)
        {
            var atividade = Mapper.Map<Atividade, AtividadeViewModel>(_aplicacaoAtividade.RetornaPorId(id));
            return View(atividade);
        }

        // GET: Atividade/Nova
        public ActionResult Nova()
        {
            return View();
        }

        // POST: Atividade/Nova        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nova(AtividadeViewModel atividade)
        {
            if (ModelState.IsValid)
            {
                var atividadeDominio = Mapper.Map<AtividadeViewModel, Atividade>(atividade);
                _aplicacaoAtividade.Adicionar(atividadeDominio);

                return RedirectToAction("Index");
            }

            return View(atividade);
        }

        // GET: Atividade/Atualizar/5
        public ActionResult Atualizar(int id)
        {
            var atividade = Mapper.Map<Atividade, AtividadeViewModel>(_aplicacaoAtividade.RetornaPorId(id));
            return View(atividade);
        }

        // POST: Atividade/Atualizar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Atualizar(AtividadeViewModel atividade)
        {
            if (ModelState.IsValid)
            {
                var atividadeDominio = Mapper.Map<AtividadeViewModel, Atividade>(atividade);
                _aplicacaoAtividade.Atualizar(atividadeDominio);

                return RedirectToAction("Index");
            }

            return View(atividade);
        }

        // GET: Atividade/Excluir/5
        public ActionResult Excluir(int id)
        {
            return View();
        }

        // POST: Atividade/Excluir/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfimado(int id)
        {
            var cliente = _aplicacaoAtividade.RetornaPorId(id);
            _aplicacaoAtividade.Excluir(cliente);

            return RedirectToAction("Index");
        }
    }
}
