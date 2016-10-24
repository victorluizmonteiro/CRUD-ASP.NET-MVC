using Fiap.Revisao.PS.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Revisao.PS.MVC.Web.Repositories
{
    public interface IStartupRepository
    {
        void Cadastrar(Startup startup);
        List<Startup> Listar();
    }
}
