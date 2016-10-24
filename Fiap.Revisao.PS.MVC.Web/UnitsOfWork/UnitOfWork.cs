using Fiap.Revisao.PS.MVC.Web.Contexts;
using Fiap.Revisao.PS.MVC.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap.Revisao.PS.MVC.Web.UnitsOfWork
{
    public class UnitOfWork : IDisposable
    {
        private RevisaoContext _context = new RevisaoContext();

        private IStartupRepository _startupRepository;

        private IProjetoRepository _projetoRepository;

        public IProjetoRepository ProjetoRepository
        {
            get
            {
                if (_projetoRepository == null)
                {
                    _projetoRepository = 
                        new ProjetoRepository(_context);
                }
                return _projetoRepository;
            }
        }

        public IStartupRepository StartupRepository
        {
            get
            {
                if (_startupRepository == null)
                {
                    _startupRepository = 
                        new StartupRepository(_context);
                }
                return _startupRepository;
            }
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        bool _disposed = false;

        public void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}