using CustomerManagement.Application.Interfaces;
using CustomerManagement.Application.Models;
using CustomerManager.Inferstructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Infrastructure
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly CustomerDbContext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(CustomerDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
        
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IRepository<T>)_repositories[typeof(T)];
            }
            var rep = new Repository<T>(_context);
            _repositories.Add(typeof(T), rep);
            return rep;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
