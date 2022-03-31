using AutoMapper;
using Bairrista.Service.Map;
using Bairrista.Service.Model;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bairrista.Dominio.Service
{
    public interface IOrcamentoService
    {
        List<OrcamentoResponse> Listar(ComumQuery query);
        OrcamentoResponse Obter(int id);
        OrcamentoResponse Salvar(OrcamentoRequest OrcamentoService);
        OrcamentoResponse Alterar(int id, OrcamentoRequest OrcamentoService);                
    }

    public class OrcamentoService : IOrcamentoService
    {
        IOrcamentoDomain _domain;        
        IUsuarioService _usuarioService;        
        IMapper _mapper;
        public OrcamentoService(DashboardContext context, IUsuarioService usuarioService)
        {
            _mapper = AutoMapping.mapper;
            _domain = new OrcamentoDomain(context);
            _usuarioService = usuarioService;            
        }
        public List<OrcamentoResponse> Listar(ComumQuery query)
        {
            ExpressionStarter<Orcamento> filter = PredicateBuilder.New<Orcamento>(a => true);

            if (query.usuario_id > 0)
                filter.And(a => a.Usuario.Id == query.usuario_id);

            Type myType = typeof(Orcamento);
       
            var _retorno = _domain.Listar(filter);          

            return _mapper.Map<List<OrcamentoResponse>>(_retorno);
        }



        public OrcamentoResponse Obter(int id)
        {
            return _mapper.Map<OrcamentoResponse>(_domain.Obter(id));
        }

        public OrcamentoResponse Salvar(OrcamentoRequest request)
        {
            Orcamento _request = _mapper.Map<Orcamento>(request);
            UsuarioResponse _usuario = _usuarioService.Obter(request.usuario_id);
            if (_usuario == null)
                throw new Exception("");

            _request.UsuarioId = _usuario.id;

            _request = _domain.Salvar(_request);
            return _mapper.Map<OrcamentoResponse>(_request);
        }

        public OrcamentoResponse Alterar(int id, OrcamentoRequest request)
        {
            Orcamento _request = _mapper.Map<Orcamento>(request);           
            UsuarioResponse _usuario = _usuarioService.Obter(request.usuario_id);
            if (_usuario == null)
                throw new Exception("");

            _request.UsuarioId = _usuario.id;

            _request = _domain.Alterar(_request);
            return _mapper.Map<OrcamentoResponse>(_request);
        }       
     
    }
}
