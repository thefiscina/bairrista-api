using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bairrista.Dominio
{
    public interface IProfissaoDomain
    {
        List<Profissao> Listar(Expression<Func<Profissao, bool>> filter = null);
        int Contar(Expression<Func<Profissao, bool>> filter = null);        
        Profissao Obter(int id);
        Profissao Salvar(Profissao Profissao);        
    }

    public class ProfissaoDomain : IProfissaoDomain
    {
        IRepository<Profissao> _baseRepository;
        public ProfissaoDomain(DbContext context)
        {
            _baseRepository = new Repository<Profissao>(context);
        }

        public List<Profissao> Listar(Expression<Func<Profissao, bool>> filter = null)
        {
            return _baseRepository.Listar(filter);
        }

        public int Contar(Expression<Func<Profissao, bool>> filter = null)
        {
            return _baseRepository.Contar(filter);
        }

        public Profissao Salvar(Profissao Profissao)
        {
            Profissao = _baseRepository.Save(Profissao);
            _baseRepository.SaveChanges();
            return Profissao;
        }
        public Profissao Obter(int id)
        {
            return _baseRepository.GetById(id);
        }
    }
}