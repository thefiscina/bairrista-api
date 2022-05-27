using AutoMapper;
using Bairrista.Dominio.SeedWork;
using Bairrista.Service.Map;
using Bairrista.Service.Model;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bairrista.Dominio.Service
{
    public interface IUsuarioService
    {
        List<UsuarioResponse> Listar(UsuarioQuery query);
        //UsuarioResponse Obter(string uuid);
        UsuarioResponse ObterPorCpf(string cpf);
        UsuarioResponse Obter(int id);
        UsuarioResponse Salvar(UsuarioRequest cliente);
        UsuarioResponse Alterar(int id, UsuarioRequest cliente);
        List<UsuarioResponse> ListarComEndereco(UsuarioQuery query);
        List<UsuarioResponse> ListarProfissionais(UsuarioQuery query);
        UsuarioResponse SalvarSocial(UsuarioRequest cliente);
    }

    public class UsuarioService : IUsuarioService
    {
        IUsuarioDomain _domain;
        IMapper _mapper;
        public UsuarioService(DashboardContext context)
        {
            _mapper = AutoMapping.mapper;
            _domain = new UsuarioDomain(context);
        }
        public List<UsuarioResponse> Listar(UsuarioQuery query)
        {
            ExpressionStarter<Usuario> filter = PredicateBuilder.New<Usuario>(a => true);        
        
            if (!string.IsNullOrEmpty(query.cpf))
                filter.And(a => a.Cpf == query.cpf);

            if (!string.IsNullOrEmpty(query.email))
                filter.And(a => a.Email == query.email);


            if (!string.IsNullOrEmpty(query.profissao))
            {
                string texto = query.profissao.ToLower();
                filter.And(a => a.Profissao.ToLower().Contains(texto));
            }                

            string includeProperties = "Enderecos,Orcamentos,Avaliacoes";

            var _retorno = _domain.Listar(filter, includeProperties);

 

            return _mapper.Map<List<UsuarioResponse>>(_retorno);
        }
        public UsuarioResponse Salvar(UsuarioRequest request)
        {
            var _entidadeDominio = _mapper.Map<Usuario>(request);         
            Auth.CriarSenhaHash(request.senha);          
            _entidadeDominio = _domain.Salvar(_entidadeDominio);
            return _mapper.Map<UsuarioResponse>(_entidadeDominio);
        }
       public UsuarioResponse SalvarSocial(UsuarioRequest request)
        {
            var _entidadeDominio = _mapper.Map<Usuario>(request);
            Auth.CriarSenhaHash(request.senha);
            _entidadeDominio = _domain.SalvarSocial(_entidadeDominio);
            return _mapper.Map<UsuarioResponse>(_entidadeDominio);
        }
        public UsuarioResponse Alterar(int id, UsuarioRequest request)
        {
            var _request = _mapper.Map<Usuario>(request);
        
            _request = _domain.Alterar(_request, id);
            if (!string.IsNullOrEmpty(request.senha))
            {
                Auth.CriarSenhaHash(request.senha);             
            }

            return _mapper.Map<UsuarioResponse>(_request);
        }

        public List<UsuarioResponse> ListarProfissionais(UsuarioQuery query)
        {
            ExpressionStarter<Usuario> filter = PredicateBuilder.New<Usuario>(a => true);

            if (!string.IsNullOrEmpty(query.cpf))
                filter.And(a => a.Cpf == query.cpf);


            if (!string.IsNullOrEmpty(query.profissao))
            {
                string texto = query.profissao.ToLower();
                filter.And(a => a.Profissao.ToLower().Contains(texto));
            }

            filter.And(a => a.Profissao != null && a.Profissao != "");

            string includeProperties = "Enderecos,Orcamentos,Avaliacoes";

            var _retorno = _domain.Listar(filter, includeProperties);



            return _mapper.Map<List<UsuarioResponse>>(_retorno);
        }
        public UsuarioResponse ObterPorCpf(string cpf)
        {
            ExpressionStarter<Usuario> filter = PredicateBuilder.New<Usuario>(a => true);

            if (string.IsNullOrEmpty(cpf))
                throw new Exception();

            filter.And(a => a.Cpf == cpf);
            return _mapper.Map<UsuarioResponse>(_domain.Listar(filter).FirstOrDefault());
        }

        public List<UsuarioResponse> ListarComEndereco(UsuarioQuery query)
        {
            ExpressionStarter<Usuario> filter = PredicateBuilder.New<Usuario>(a => true);

            if (!string.IsNullOrEmpty(query.cpf))
                filter.And(a => a.Cpf == query.cpf);


            if (!string.IsNullOrEmpty(query.profissao))
            {
                string texto = query.profissao.ToLower();
                filter.And(a => a.Profissao.ToLower().Contains(texto));
            }

            string includeProperties = "Endereco";

            var _retorno = _domain.Listar(filter, includeProperties);



            return _mapper.Map<List<UsuarioResponse>>(_retorno);
        }
        public UsuarioResponse Obter(int id)
        {
            return _mapper.Map<UsuarioResponse>(_domain.Obter(id));
        }
    }
}