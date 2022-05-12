using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bairrista.Dominio
{
    public interface IOrcamentoRespostaDomain
    {
        List<OrcamentoResposta> Listar(Expression<Func<OrcamentoResposta, bool>> filter = null);
        int Contar(Expression<Func<OrcamentoResposta, bool>> filter = null);        
        OrcamentoResposta Obter(int id);
        OrcamentoResposta Salvar(OrcamentoResposta OrcamentoResposta);
        //OrcamentoResposta Alterar(OrcamentoResposta OrcamentoResposta);
    }

    public class OrcamentoRespostaDomain : IOrcamentoRespostaDomain
    {
        IRepository<OrcamentoResposta> _baseRepository;
        public OrcamentoRespostaDomain(DbContext context)
        {
            _baseRepository = new Repository<OrcamentoResposta>(context);
        }

        public List<OrcamentoResposta> Listar(Expression<Func<OrcamentoResposta, bool>> filter = null)
        {
            return _baseRepository.Listar(filter);
        }

        public int Contar(Expression<Func<OrcamentoResposta, bool>> filter = null)
        {
            return _baseRepository.Contar(filter);
        }

        public OrcamentoResposta Salvar(OrcamentoResposta OrcamentoResposta)
        {
            OrcamentoResposta = _baseRepository.Save(OrcamentoResposta);
            _baseRepository.SaveChanges();
            return OrcamentoResposta;
        }

        //public OrcamentoResposta Alterar(OrcamentoResposta OrcamentoResposta)
        //{
        //    OrcamentoResposta _OrcamentoResposta = Obter(OrcamentoResposta.Id);
        //    if (_OrcamentoResposta == null)
        //    {
        //        _OrcamentoResposta = Obter(OrcamentoResposta.Id);
        //        if (_OrcamentoResposta == null)
        //            throw new System.Exception();
        //    }
        //    _OrcamentoResposta.Descricao = OrcamentoResposta.Descricao;
        //    _OrcamentoResposta.DataHoraOrcamentoResposta = OrcamentoResposta.DataHoraOrcamentoResposta;
        //    _OrcamentoResposta.StatusOrcamentoResposta = OrcamentoResposta.StatusOrcamentoResposta;          
        //    _OrcamentoResposta = _baseRepository.Update(_OrcamentoResposta);
        //    _baseRepository.SaveChanges();
        //    return _OrcamentoResposta;
        //}

        //public OrcamentoResposta Obter(int id)
        //{
        //    return _baseRepository.Consultar(PredicateBuilder.New<OrcamentoResposta>().And(a => a.Id == id),null,null,null,"Usuario").FirstOrDefault();
        //}

        public OrcamentoResposta Obter(int id)
        {
          
            return _baseRepository.GetById(id);
        }
    }
}