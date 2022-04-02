using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bairrista.Dominio
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private protected DbContext _context;

        internal Repository(DbContext context)
        {
            _context = context;
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public TEntity Save(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        public void RemoveRange(List<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void AddOrUpdateRange(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _ = !_context.Set<TEntity>().Any(e => e == entity) ? this.Save(entity) : this.Update(entity);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<TEntity> Listar(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {
            return Consultar(filter, includeProperties).ToList();
        }

        public IQueryable<TEntity> Consultar(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
              (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query;

        }

        public int Contar(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.Count();
        }
    }
}