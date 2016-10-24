using Fiap.Revisao.PS.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Fiap.Revisao.PS.MVC.Web.Contexts
{
    public class RevisaoContext : DbContext
    {
        public DbSet<Startup> Startups { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
    }
}