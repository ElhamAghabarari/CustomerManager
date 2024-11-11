using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);

        int Add(T item);
    }
}
