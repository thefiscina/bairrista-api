using AutoMapper;
using Bairrista.Service.Map;
using Bairrista.Service.Model;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bairrista.Dominio.Service
{
    public interface IPagamentoUsuarioService
    {
        List<PagamentoUsuarioResponse> Listar(ComumQuery query);
        PagamentoUsuarioResponse Obter(int id);
        PagamentoUsuarioResponse Salvar(PagamentoUsuarioRequest PagamentoUsuarioService);           
    }

    public class PagamentoUsuarioService : IPagamentoUsuarioService
    {
        IPagamentoUsuarioDomain _domain;        
        IUsuarioService _usuarioService;        
        IMapper _mapper;
        public PagamentoUsuarioService(DashboardContext context, IUsuarioService usuarioService)
        {
            _mapper = AutoMapping.mapper;
            _domain = new PagamentoUsuarioDomain(context);
            _usuarioService = usuarioService;            
        }
        public List<PagamentoUsuarioResponse> Listar(ComumQuery query)
        {
            ExpressionStarter<PagamentoUsuario> filter = PredicateBuilder.New<PagamentoUsuario>(a => true);

            if (query.usuario_id > 0)
                filter.And(a => a.Usuario.Id == query.usuario_id);

            Type myType = typeof(PagamentoUsuario);
       
            var _retorno = _domain.Listar(filter);          

            return _mapper.Map<List<PagamentoUsuarioResponse>>(_retorno);
        }



        public PagamentoUsuarioResponse Obter(int id)
        {
            return _mapper.Map<PagamentoUsuarioResponse>(_domain.Obter(id));
        }

        public PagamentoUsuarioResponse Salvar(PagamentoUsuarioRequest request)
        {
            PagamentoUsuario _request = _mapper.Map<PagamentoUsuario>(request);
            UsuarioResponse _usuario = _usuarioService.Obter(request.usuario_id);
            if (_usuario == null)
                throw new Exception("");

            _request.UsuarioId = _usuario.id;

            _request = _domain.Salvar(_request);
            return _mapper.Map<PagamentoUsuarioResponse>(_request);
        }
            
    }
}
