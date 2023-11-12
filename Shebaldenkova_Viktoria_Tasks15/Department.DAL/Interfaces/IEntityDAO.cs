using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department.DAL
{
    public interface IEntityDAO<T,S>
    {
        void Add(S entity);

        void Edit(T entity);

        void Remove(T entity);

        IEnumerable<T> GetList();

    }
}
