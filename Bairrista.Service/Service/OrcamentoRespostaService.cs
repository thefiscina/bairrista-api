using AutoMapper;
using Bairrista.Service.Map;
using Bairrista.Service.Model;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bairrista.Dominio.Service
{
    public interface IOrcamentoRespostaService
    {
        List<OrcamentoRespostaResponse> Listar(OrcamentoRespostaQuery query);
        OrcamentoRespostaResponse Obter(int id);
        OrcamentoRespostaResponse Salvar(OrcamentoRespostaRequest OrcamentoRespostaService);
                     
    }

    public class OrcamentoRespostaService : IOrcamentoRespostaService
    {
        IOrcamentoRespostaDomain _domain;        
        IUsuarioService _usuarioService;        
        IMapper _mapper;
        public OrcamentoRespostaService(DashboardContext context, IUsuarioService usuarioService)
        {
            _mapper = AutoMapping.mapper;
            _domain = new OrcamentoRespostaDomain(context);
            _usuarioService = usuarioService;            
        }
        public List<OrcamentoRespostaResponse> Listar(OrcamentoRespostaQuery query)
        {
            ExpressionStarter<OrcamentoResposta> filter = PredicateBuilder.New<OrcamentoResposta>(a => true);

            if (query.orcamento_id > 0)
                filter.And(a => a.Orcamento.Id == query.orcamento_id);

            Type myType = typeof(OrcamentoResposta);
       
            var _retorno = _domain.Listar(filter);          

            return _mapper.Map<List<OrcamentoRespostaResponse>>(_retorno);
        }



        public OrcamentoRespostaResponse Obter(int id)
        {
            return _mapper.Map<OrcamentoRespostaResponse>(_domain.Obter(id));
        }

        public OrcamentoRespostaResponse Salvar(OrcamentoRespostaRequest request)
        {
            OrcamentoResposta _request = _mapper.Map<OrcamentoResposta>(request);
            //UsuarioResponse _usuario = _usuarioService.Obter(request.usuario_id);
            //if (_usuario == null)
            //    throw new Exception("");

            //_request.UsuarioId = _usuario.id;

            _request = _domain.Salvar(_request);
            return _mapper.Map<OrcamentoRespostaResponse>(_request);
        }
      
     
    }
}
