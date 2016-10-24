using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Fiap.Revisao.PS.MVC.Web.Models;
using Fiap.Revisao.PS.MVC.Web.Contexts;

namespace Fiap.Revisao.PS.MVC.Web.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private RevisaoContext _context;

        public ProjetoRepository(RevisaoContext context)
        {
            _context = context;
        }

        public void Aprovar(int id)
        {
            var projeto = BuscarPorId(id);
            projeto.Status = Status.Aprovado;
        }

        public List<Projeto> BuscarPor(Expression<Func<Projeto, bool>> filtro)
        {
            return _context.Projetos.Include("Startup").Where(filtro).ToList();
        }

        public Projeto BuscarPorId(int id)
        {
            return _context.Projetos.Find(id);
        }

        public void Cadastrar(Projeto projeto)
        {
            projeto.Status = Status.Aguardando;
            _context.Projetos.Add(projeto);
        }

        public void Editar(Projeto projeto)
        {
            _context.Entry(projeto).State = System.Data.Entity.EntityState.Modified;
        }

        public void Excluir(int id)
        {
            var projeto = BuscarPorId(id);
            _context.Projetos.Remove(projeto);
        }

        public List<Projeto> Listar()
        {
           return  _context.Projetos.Include("Startup").ToList();
        }

        public void Reprovar(int id)
        {
            var projeto = BuscarPorId(id);
            projeto.Status = Status.Reprovado;
        }
    }
}