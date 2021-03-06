﻿using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositorys
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected DbContext _context { get; set; }
        public GenericRepository() : this(new AngleSharpEntities())
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
            }
        }
        public void CreateAll(List<T> datas)
        {
            if (datas.Count() == 0)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                this._context.Set<T>().AddRange(datas);
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
        }
        public T Get(Expression<Func<T, bool>> predicate)
        {
            return this._context.Set<T>().FirstOrDefault(predicate);
        }
        public IQueryable<T> GetAll()
        {
            return this._context.Set<T>().AsQueryable();
        }
        public IQueryable<T> GetAllById(Expression<Func<T, bool>> predicate)
        {
            var data = this._context.Set<T>().Where(predicate);
            if (data == null)
            {
                throw new ArgumentNullException("instance");
            }
            return data;
        }
        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return this._context.Set<T>().Any(predicate);
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
