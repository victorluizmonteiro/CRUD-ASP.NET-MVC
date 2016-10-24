using Fiap.Revisao.PS.MVC.Web.Models;
using Fiap.Revisao.PS.MVC.Web.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Revisao.PS.MVC.Web.Controllers
{
    public class ProjetoController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Buscar(string nomeBusca)
        {
            var lista = _unit.ProjetoRepository.BuscarPor(
                p => p.Nome.Contains(nomeBusca));
            return View("Listar",lista);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var projeto = _unit.ProjetoRepository.BuscarPorId(id);
            CarregarStartups();
            return View(projeto);
        }

        [HttpPost]
        public ActionResult Editar(Projeto projeto)
        {
            if (ModelState.IsValid)
            {
                _unit.ProjetoRepository.Editar(projeto);
                _unit.Salvar();
                TempData["msg"] = "Projeto Atualizado";
                return RedirectToAction("Listar");
            }
            else
            {
                CarregarStartups();
                return View(projeto);
            }
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            _unit.ProjetoRepository.Excluir(id);
            _unit.Salvar();
            TempData["msg"] = "Projeto Removido!";
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Aprovar(int id)
        {
            _unit.ProjetoRepository.Aprovar(id);
            _unit.Salvar();
            TempData["msg"] = "Projeto Aprovado!";
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Reprovar(int id)
        {
            _unit.ProjetoRepository.Reprovar(id);
            _unit.Salvar();
            TempData["msg"] = "Projeto Reprovado!";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            CarregarStartups();
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Projeto projeto)
        {
            if (ModelState.IsValid)
            {
                _unit.ProjetoRepository.Cadastrar(projeto);
                _unit.Salvar();
                TempData["msg"] = "Cadastrado!";
                return RedirectToAction("Cadastrar");
            }
            else
            {
                CarregarStartups();
                return View(projeto);
            }
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var lista = _unit.ProjetoRepository.Listar();
            return View(lista);
        }

        private void CarregarStartups()
        {
            var lista = _unit.StartupRepository.Listar();
            ViewBag.opcoes = new SelectList(lista, "StartupId", "Nome");
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}