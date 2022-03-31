using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bairrista.Dominio
{
    public interface IEnderecoDomain
    {
        List<Endereco> Listar(Expression<Func<Endereco, bool>> filter = null);
        int Contar(Expression<Func<Endereco, bool>> filter = null);
        //Endereco Obter(string uuid);
        Endereco Obter(int id);
        Endereco Salvar(Endereco Endereco);
        Endereco Alterar(Endereco Endereco);
    }

    public class EnderecoDomain : IEnderecoDomain
    {
        IRepository<Endereco> _baseRepository;
        public EnderecoDomain(DbContext context)
        {
            _baseRepository = new Repository<Endereco>(context);
        }

        public List<Endereco> Listar(Expression<Func<Endereco, bool>> filter = null)
        {
            return _baseRepository.Listar(filter);
        }

        public int Contar(Expression<Func<Endereco, bool>> filter = null)
        {
            return _baseRepository.Contar(filter);
        }

        public Endereco Salvar(Endereco Endereco)
        {
            Endereco = _baseRepository.Save(Endereco);
            _baseRepository.SaveChanges();
            return Endereco;
        }

        public Endereco Alterar(Endereco Endereco)
        {
            Endereco _Endereco = Obter(Endereco.Id);
            if (_Endereco == null)
            {
                _Endereco = Obter(Endereco.Id);
                if (_Endereco == null)
                    throw new System.Exception();
            }
            _Endereco.Logradouro = Endereco.Logradouro;
            _Endereco.Bairro = Endereco.Bairro;
            _Endereco.Cidade = Endereco.Cidade;
            _Endereco.Latitude = Endereco.Latitude;
            _Endereco.Longitude = Endereco.Longitude;     
            _Endereco.Usuario = Endereco.Usuario;
            

            _Endereco = _baseRepository.Update(_Endereco);
            _baseRepository.SaveChanges();
            return _Endereco;
        }

        //public Endereco Obter(int id)
        //{
        //    return _baseRepository.Consultar(PredicateBuilder.New<Endereco>().And(a => a.Id == id),null,null,null,"Usuario").FirstOrDefault();
        //}

        public Endereco Obter(int id)
        {
            return _baseRepository.GetById(id);
        }
    }
}