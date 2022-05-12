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
        List<OrcamentoRespostaResponse> Listar(int id);
        OrcamentoRespostaResponse Obter(int id);
        OrcamentoRespostaResponse Salvar(OrcamentoRespostaRequest OrcamentoRespostaRequest);
                     
    }

    public class OrcamentoRespostaService : IOrcamentoRespostaService
    {
        IOrcamentoRespostaDomain _domain;        
        IUsuarioService _usuarioService;
        IOrcamentoService _orcaemntoService;
        IMapper _mapper;
        public OrcamentoRespostaService(DashboardContext context, IUsuarioService usuarioService, IOrcamentoService orcamentoService)
        {
            _mapper = AutoMapping.mapper;
            _domain = new OrcamentoRespostaDomain(context);
            _usuarioService = usuarioService;
            _orcaemntoService = orcamentoService;

        }
        public List<OrcamentoRespostaResponse> Listar(int id)
        {
            ExpressionStarter<OrcamentoResposta> filter = PredicateBuilder.New<OrcamentoResposta>(a => true);

            if (id > 0)
                filter.And(a => a.Orcamento.Id == id);

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

            OrcamentoResponse _orcamento = _orcaemntoService.Obter(request.orcamento_id);

            if (_orcamento == null)
            {
                throw new Exception("Orçamento não encontrado");
            }

            _request.OrcamentoId = _orcamento.id;       
            _request = _domain.Salvar(_request);
            return _mapper.Map<OrcamentoRespostaResponse>(_request);                 
         
        }
      
     
    }
}
