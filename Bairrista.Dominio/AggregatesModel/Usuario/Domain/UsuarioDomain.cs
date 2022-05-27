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
        List<Usuario> Listar(Expression<Func<Usuario, bool>> filter = null, string includeProperties = "");                
        Usuario Obter(int id);
        Usuario ObterPorLogin(string login);
        Usuario ObterPorEmail(string login);
        Usuario Salvar(Usuario cliente);
        Usuario SalvarSocial(Usuario cliente);
        Usuario Alterar(Usuario cliente, int id);
    }

    public class UsuarioDomain : IUsuarioDomain
    {
        IRepository<Usuario> _baseRepository;
        public UsuarioDomain(DbContext context)
        {
            _baseRepository = new Repository<Usuario>(context);
        }

        public List<Usuario> Listar(Expression<Func<Usuario, bool>> filter = null, string includeProperties = "")
        {            
            return _baseRepository.Listar(filter, includeProperties);
        }

        public Usuario Salvar(Usuario usuario)
        {
            Usuario _usuario = ObterPorLogin(usuario.Cpf);
            if(_usuario != null)
            {
                throw new Exception("Usuário já cadastrado");
            }
            if (!String.IsNullOrEmpty(usuario.Profissao))
            {
                usuario.TipoUsuario = UsuarioType.PROFISSIONAL;
            }
            else
            {
                usuario.TipoUsuario = UsuarioType.COMUM;
            }
            _baseRepository.Save(usuario);
            _baseRepository.SaveChanges();
            return usuario;
        }

        public Usuario SalvarSocial(Usuario usuario)
        {
            Usuario _usuario = ObterPorEmail(usuario.Email);
            if (_usuario != null)
            {
                throw new Exception("Usuário já cadastrado");
            }
            if (!String.IsNullOrEmpty(usuario.Profissao))
            {
                usuario.TipoUsuario = UsuarioType.PROFISSIONAL;
            }
            else
            {
                usuario.TipoUsuario = UsuarioType.COMUM;
            }
            _baseRepository.Save(usuario);
            _baseRepository.SaveChanges();
            return usuario;
        }

        public Usuario Alterar(Usuario usuario,int id)
        {
            Usuario _usuario = Obter(id); 
            if (_usuario == null)
            {
                throw new System.Exception("Usuário não encontrado");
            }
            _usuario.Nome = usuario.Nome;
            _usuario.Sobrenome = usuario.Sobrenome;     
            _usuario.Email = usuario.Email;
            _usuario.Telefone = usuario.Telefone;
            if (!String.IsNullOrEmpty(usuario.Profissao)){
                _usuario.Profissao = usuario.Profissao;
                _usuario.TipoUsuario = UsuarioType.PROFISSIONAL;
            }
            else
            {
                _usuario.TipoUsuario = UsuarioType.COMUM;
            }

            _baseRepository.Update(_usuario);
            _baseRepository.SaveChanges();
            return _usuario;
        }
    

        public Usuario ObterPorLogin(string login)
        {
            return _baseRepository.Consultar(PredicateBuilder.New<Usuario>().And(a => a.Cpf == login)).FirstOrDefault();
        }

        public Usuario ObterPorEmail(string email)
        {
            return _baseRepository.Consultar(PredicateBuilder.New<Usuario>().And(a => a.Email == email)).FirstOrDefault();
        }


        public Usuario Obter(int id)
        {
            return _baseRepository.GetById(id);
        }
       
    }
}