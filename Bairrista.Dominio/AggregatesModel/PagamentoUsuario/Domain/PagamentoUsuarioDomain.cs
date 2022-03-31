using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bairrista.Dominio
{
    public interface IPagamentoUsuarioDomain
    {
        List<PagamentoUsuario> Listar(Expression<Func<PagamentoUsuario, bool>> filter = null);
        int Contar(Expression<Func<PagamentoUsuario, bool>> filter = null);        
        PagamentoUsuario Obter(int id);
        PagamentoUsuario Salvar(PagamentoUsuario PagamentoUsuario);
        //PagamentoUsuario Alterar(PagamentoUsuario PagamentoUsuario);
    }

    public class PagamentoUsuarioDomain : IPagamentoUsuarioDomain
    {
        IRepository<PagamentoUsuario> _baseRepository;
        public PagamentoUsuarioDomain(DbContext context)
        {
            _baseRepository = new Repository<PagamentoUsuario>(context);
        }

        public List<PagamentoUsuario> Listar(Expression<Func<PagamentoUsuario, bool>> filter = null)
        {
            return _baseRepository.Listar(filter);
        }

        public int Contar(Expression<Func<PagamentoUsuario, bool>> filter = null)
        {
            return _baseRepository.Contar(filter);
        }

        public PagamentoUsuario Salvar(PagamentoUsuario PagamentoUsuario)
        {
            PagamentoUsuario = _baseRepository.Save(PagamentoUsuario);
            _baseRepository.SaveChanges();
            return PagamentoUsuario;
        }

        //public PagamentoUsuario Alterar(PagamentoUsuario PagamentoUsuario)
        //{
        //    PagamentoUsuario _PagamentoUsuario = Obter(PagamentoUsuario.Id);
        //    if (_PagamentoUsuario == null)
        //    {
        //        _PagamentoUsuario = Obter(PagamentoUsuario.Id);
        //        if (_PagamentoUsuario == null)
        //            throw new System.Exception();
        //    }
        //    _PagamentoUsuario.Descricao = PagamentoUsuario.Descricao;
        //    _PagamentoUsuario.DataHoraPagamentoUsuario = PagamentoUsuario.DataHoraPagamentoUsuario;
        //    _PagamentoUsuario.StatusPagamentoUsuario = PagamentoUsuario.StatusPagamentoUsuario;          
        //    _PagamentoUsuario = _baseRepository.Update(_PagamentoUsuario);
        //    _baseRepository.SaveChanges();
        //    return _PagamentoUsuario;
        //}

        //public PagamentoUsuario Obter(int id)
        //{
        //    return _baseRepository.Consultar(PredicateBuilder.New<PagamentoUsuario>().And(a => a.Id == id),null,null,null,"Usuario").FirstOrDefault();
        //}

        public PagamentoUsuario Obter(int id)
        {
            return _baseRepository.GetById(id);
        }
    }
}