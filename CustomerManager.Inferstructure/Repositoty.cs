using CustomerManagement.Application.Interfaces;
using CustomerManager.Inferstructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Infrastructure
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly CustomerDbContext _context;

        public Repository(CustomerDbContext context)
        {
            _context = context;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public int Add(T item)
        {
            _context.Set<T>().Add(item);
            return 0;
        }
    }
}
