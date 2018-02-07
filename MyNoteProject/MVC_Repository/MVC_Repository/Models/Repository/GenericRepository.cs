using MVC_Repository.Models.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MVC_Repository.Models.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private DbContext _context { get; set; }
        public GenericRepository() : this(new NorthwindEntities())
        {
        }
        public GenericRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this._context = context;
        }
        public GenericRepository(ObjectContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this._context = new DbContext(context, true);
        }

        public void Create(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                this._context.Set<T>().Add(data);
                this.SaveChanges();
            }
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            var data = this._context.Set<T>().FirstOrDefault(predicate);
            if (data == null)
            {
                throw new ArgumentNullException("instance");
            }            
            this._context.Entry(data).State = EntityState.Deleted;
            this.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return this._context.Set<T>().FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return this._context.Set<T>().AsQueryable();
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public void Update(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                this._context.Entry(data).State = EntityState.Modified;
                this.SaveChanges();
            }
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._context != null)
                {
                    this._context.Dispose();
                    this._context = null;
                }
            }
        }
    }
}