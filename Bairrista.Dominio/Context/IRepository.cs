using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bairrista.Dominio
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> Consultar(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");        
        List<TEntity> Listar(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");
        int Contar(Expression<Func<TEntity, bool>> filter = null);
        TEntity GetById(int id);
        TEntity Save(TEntity entity);
        TEntity Update(TEntity entity);
        void Remove(TEntity entity);
        public void RemoveRange(List<TEntity> entities);
        void SaveChanges();
    }
}