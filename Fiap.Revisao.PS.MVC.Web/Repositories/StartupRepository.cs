using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fiap.Revisao.PS.MVC.Web.Models;
using Fiap.Revisao.PS.MVC.Web.Contexts;

namespace Fiap.Revisao.PS.MVC.Web.Repositories
{
    public class StartupRepository : IStartupRepository
    {
        private RevisaoContext _context;

        public StartupRepository(RevisaoContext context)
        {
            _context = context;
        }

        public void Cadastrar(Startup startup)
        {
            _context.Startups.Add(startup);
        }

        public List<Startup> Listar()
        {
            return _context.Startups.ToList();
        }
    }
}