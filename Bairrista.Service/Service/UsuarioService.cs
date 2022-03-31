﻿using AutoMapper;
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

            //if (query.id > 0)
            //    filter.And(a => a.Id == query.id);

            if (!string.IsNullOrEmpty(query.profissao))
                filter.And(a => a.Profissao == query.profissao);



            var _retorno = _domain.Listar(filter);

 

            return _mapper.Map<List<UsuarioResponse>>(_retorno);
        }
        public UsuarioResponse Salvar(UsuarioRequest request)
        {
            var _entidadeDominio = _mapper.Map<Usuario>(request);         
            Auth.CriarSenhaHash(request.senha);          
            _entidadeDominio = _domain.Salvar(_entidadeDominio);
            return _mapper.Map<UsuarioResponse>(_entidadeDominio);
        }
        public UsuarioResponse Alterar(int id, UsuarioRequest request)
        {
            var _request = _mapper.Map<Usuario>(request);
        
            _request = _domain.Alterar(_request);
            if (!string.IsNullOrEmpty(request.senha))
            {
                Auth.CriarSenhaHash(request.senha);             
            }

            return _mapper.Map<UsuarioResponse>(_request);
        }
       

        public UsuarioResponse ObterPorCpf(string cpf)
        {
            ExpressionStarter<Usuario> filter = PredicateBuilder.New<Usuario>(a => true);

            if (string.IsNullOrEmpty(cpf))
                throw new Exception();

            filter.And(a => a.Cpf == cpf);
            return _mapper.Map<UsuarioResponse>(_domain.Listar(filter).FirstOrDefault());
        }
        public UsuarioResponse Obter(int id)
        {
            return _mapper.Map<UsuarioResponse>(_domain.Obter(id));
        }
    }
}