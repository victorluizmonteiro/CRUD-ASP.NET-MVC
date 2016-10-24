using Fiap.Revisao.PS.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Revisao.PS.MVC.Web.Repositories
{
    public interface IProjetoRepository
    {
        void Cadastrar(Projeto projeto);
        List<Projeto> Listar();
        void Editar(Projeto projeto);
        void Excluir(int id);
        Projeto BuscarPorId(int id);
        List<Projeto> BuscarPor(
            Expression<Func<Projeto, bool>> filtro);
        void Aprovar(int id);
        void Reprovar(int id);
        
    }
}
