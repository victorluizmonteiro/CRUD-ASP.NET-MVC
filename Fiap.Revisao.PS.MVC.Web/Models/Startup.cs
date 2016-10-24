using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap.Revisao.PS.MVC.Web.Models
{
    public class Startup
    {
        public int StartupId { get; set; }
        public string Nome { get; set; }
        public decimal Faturamento { get; set; }
        public DateTime DataFundacao { get; set; }

        //Relacionamento
        public List<Projeto> Projetos { get; set; }
    }
}