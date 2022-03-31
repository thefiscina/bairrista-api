using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bairrista.Dominio
{
    public interface IOrcamentoDomain
    {
        List<Orcamento> Listar(Expression<Func<Orcamento, bool>> filter = null);
        int Contar(Expression<Func<Orcamento, bool>> filter = null);        
        Orcamento Obter(int id);
        Orcamento Salvar(Orcamento Orcamento);
        Orcamento Alterar(Orcamento Orcamento);
    }

    public class OrcamentoDomain : IOrcamentoDomain
    {
        IRepository<Orcamento> _baseRepository;
        public OrcamentoDomain(DbContext context)
        {
            _baseRepository = new Repository<Orcamento>(context);
        }

        public List<Orcamento> Listar(Expression<Func<Orcamento, bool>> filter = null)
        {
            return _baseRepository.Listar(filter);
        }

        public int Contar(Expression<Func<Orcamento, bool>> filter = null)
        {
            return _baseRepository.Contar(filter);
        }

        public Orcamento Salvar(Orcamento Orcamento)
        {
            Orcamento = _baseRepository.Save(Orcamento);
            _baseRepository.SaveChanges();
            return Orcamento;
        }

        public Orcamento Alterar(Orcamento Orcamento)
        {
            Orcamento _Orcamento = Obter(Orcamento.Id);
            if (_Orcamento == null)
            {
                _Orcamento = Obter(Orcamento.Id);
                if (_Orcamento == null)
                    throw new System.Exception();
            }
            _Orcamento.Descricao = Orcamento.Descricao;
            _Orcamento.DataHoraOrcamento = Orcamento.DataHoraOrcamento;
            _Orcamento.StatusOrcamento = Orcamento.StatusOrcamento;          
            _Orcamento = _baseRepository.Update(_Orcamento);
            _baseRepository.SaveChanges();
            return _Orcamento;
        }

        //public Orcamento Obter(int id)
        //{
        //    return _baseRepository.Consultar(PredicateBuilder.New<Orcamento>().And(a => a.Id == id),null,null,null,"Usuario").FirstOrDefault();
        //}

        public Orcamento Obter(int id)
        {
            return _baseRepository.GetById(id);
        }
    }
}