using CustomerManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CustomerManagement.Application.Interfaces
{
    public interface IUnitOfWork
    {
        void Save();

        IRepository<T> GetRepository<T>() where T : class;
    }
}
