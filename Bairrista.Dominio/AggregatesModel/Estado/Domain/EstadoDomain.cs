using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bairrista.Dominio
{
    public interface IEstadoDomain
    {
        List<Estado> Listar(Expression<Func<Estado, bool>> filter = null);
        int Contar(Expression<Func<Estado, bool>> filter = null);        
        Estado Obter(int id);
        Estado Salvar(Estado Estado);        
    }

    public class EstadoDomain : IEstadoDomain
    {
        IRepository<Estado> _baseRepository;
        public EstadoDomain(DbContext context)
        {
            _baseRepository = new Repository<Estado>(context);
        }

        public List<Estado> Listar(Expression<Func<Estado, bool>> filter = null)
        {
            return _baseRepository.Listar(filter);
        }

        public int Contar(Expression<Func<Estado, bool>> filter = null)
        {
            return _baseRepository.Contar(filter);
        }

        public Estado Salvar(Estado Estado)
        {
            Estado = _baseRepository.Save(Estado);
            _baseRepository.SaveChanges();
            return Estado;
        }
        public Estado Obter(int id)
        {
            return _baseRepository.GetById(id);
        }
    }
}