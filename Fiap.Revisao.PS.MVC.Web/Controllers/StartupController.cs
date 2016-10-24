using Fiap.Revisao.PS.MVC.Web.Models;
using Fiap.Revisao.PS.MVC.Web.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Revisao.PS.MVC.Web.Controllers
{
    public class StartupController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Startup startup)
        {
            if (ModelState.IsValid)
            {
                _unit.StartupRepository.Cadastrar(startup);
                _unit.Salvar();
                TempData["msg"] = "Cadastrado!";
                return View();
            }
            else
            {
                return View(startup);
            }            
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}