using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bairrista.Dominio
{
    public interface IUsuarioDomain
    {
        List<Usuario> Listar(Expression<Func<Usuario, bool>> filter = null);
        //Usuario Obter(string uuid);
        int Contar(Expression<Func<Usuario, bool>> filter = null);
        Usuario Obter(int id);
        Usuario ObterPorLogin(string login);
        Usuario Salvar(Usuario cliente);
        Usuario Alterar(Usuario cliente);
    }

    public class UsuarioDomain : IUsuarioDomain
    {
        IRepository<Usuario> _baseRepository;
        public UsuarioDomain(DbContext context)
        {
            _baseRepository = new Repository<Usuario>(context);
        }

        public List<Usuario> Listar(Expression<Func<Usuario, bool>> filter = null)
        {
            return _baseRepository.Listar(filter);
        }

        public Usuario Salvar(Usuario usuario)
        {
            Usuario _usuario = ObterPorLogin(usuario.Cpf);
            if(_usuario != null)
            {
                throw new Exception("Usuário já cadastrado");
            }
            _baseRepository.Save(usuario);
            _baseRepository.SaveChanges();
            return usuario;
        }

        public Usuario Alterar(Usuario usuario)
        {
            Usuario _usuario = Obter(usuario.Id);
            if (_usuario == null)
            {
                _usuario = Obter(usuario.Id);
                if (_usuario == null)
                    throw new System.Exception();
            }
            _usuario.Nome = usuario.Nome;
            _usuario.Sobrenome = usuario.Sobrenome;            
            

            _baseRepository.Update(_usuario);
            _baseRepository.SaveChanges();
            return _usuario;
        }

        //public Usuario Obter(string uuid)
        //{
        //    return _baseRepository.Consultar(PredicateBuilder.New<Usuario>().And(a => a.Uuid.ToString() == uuid)).FirstOrDefault();
        //}

        public Usuario ObterPorLogin(string login)
        {
            return _baseRepository.Consultar(PredicateBuilder.New<Usuario>().And(a => a.Cpf == login)).FirstOrDefault();
        }

        public Usuario Obter(int id)
        {
            return _baseRepository.GetById(id);
        }


        public int Contar(Expression<Func<Usuario, bool>> filter = null)
        {
            return _baseRepository.Contar(filter);
        }        
    }
}