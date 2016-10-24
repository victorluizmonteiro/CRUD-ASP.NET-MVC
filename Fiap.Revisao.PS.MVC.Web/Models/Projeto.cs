using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap.Revisao.PS.MVC.Web.Models
{
    public class Projeto
    {
        public int ProjetoId { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public decimal Valor { get; set; }
        public Status Status { get; set; }

        //Relacionamento
        public Startup Startup { get; set; }
        public int StartupId { get; set; }
    }
}