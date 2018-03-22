using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        void Create(T data);
        void CreateAll(List<T> datas);
        T Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        void Update(T data);
        void Delete(Expression<Func<T, bool>> predicate);
        void SaveChanges();
    }
}
