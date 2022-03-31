using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bairrista.Dominio
{
    public interface IMunicipioDomain
    {
        List<Municipio> Listar(Expression<Func<Municipio, bool>> filter = null);
        int Contar(Expression<Func<Municipio, bool>> filter = null);        
        Municipio Obter(int id);
        Municipio Salvar(Municipio Municipio);        
    }

    public class MunicipioDomain : IMunicipioDomain
    {
        IRepository<Municipio> _baseRepository;
        public MunicipioDomain(DbContext context)
        {
            _baseRepository = new Repository<Municipio>(context);
        }

        public List<Municipio> Listar(Expression<Func<Municipio, bool>> filter = null)
        {
            return _baseRepository.Listar(filter);
        }

        public int Contar(Expression<Func<Municipio, bool>> filter = null)
        {
            return _baseRepository.Contar(filter);
        }

        public Municipio Salvar(Municipio Municipio)
        {
            Municipio = _baseRepository.Save(Municipio);
            _baseRepository.SaveChanges();
            return Municipio;
        }
        public Municipio Obter(int id)
        {
            return _baseRepository.GetById(id);
        }
    }
}