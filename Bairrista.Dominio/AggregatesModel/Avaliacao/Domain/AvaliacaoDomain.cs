using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bairrista.Dominio
{
    public interface IAvaliacaoDomain
    {
        List<Avaliacao> Listar(Expression<Func<Avaliacao, bool>> filter = null);
        int Contar(Expression<Func<Avaliacao, bool>> filter = null);
        //Avaliacao Obter(string uuid);
        Avaliacao Obter(int id);
        Avaliacao Salvar(Avaliacao Avaliacao);
        //Avaliacao Alterar(Avaliacao Avaliacao);
    }

    public class AvaliacaoDomain : IAvaliacaoDomain
    {
        IRepository<Avaliacao> _baseRepository;
        public AvaliacaoDomain(DbContext context)
        {
            _baseRepository = new Repository<Avaliacao>(context);
        }

        public List<Avaliacao> Listar(Expression<Func<Avaliacao, bool>> filter = null)
        {
            return _baseRepository.Listar(filter);
        }

        public int Contar(Expression<Func<Avaliacao, bool>> filter = null)
        {
            return _baseRepository.Contar(filter);
        }

        public Avaliacao Salvar(Avaliacao Avaliacao)
        {
            Avaliacao = _baseRepository.Save(Avaliacao);
            _baseRepository.SaveChanges();
            return Avaliacao;
        }


        public Avaliacao Obter(int id)
        {
            return _baseRepository.GetById(id);
        }
    }
}