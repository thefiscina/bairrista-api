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
        List<OrcamentoResponse> Listar(int id, OrcamentoQuery query);
        List<OrcamentoResponse> ListarSolicitantes(int id, OrcamentoQuery query);
        OrcamentoResponse Obter(int id);
        OrcamentoResponse Salvar(OrcamentoRequest OrcamentoService);
        OrcamentoResponse Alterar(int id, OrcamentoAlterarRequest OrcamentoService);
        List<OrcamentoResponse> ListarOrcamento(int id);

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
        public List<OrcamentoResponse> Listar(int id, OrcamentoQuery query)
        {
            ExpressionStarter<Orcamento> filter = PredicateBuilder.New<Orcamento>(a => true);

            if (id > 0)
                filter.And(a => a.Usuario.Id == id);


            filter.And(a => a.StatusOrcamento == query.status_orcamento);


            Type myType = typeof(Orcamento);
       
            var _retorno = _domain.Listar(filter);          

            return _mapper.Map<List<OrcamentoResponse>>(_retorno);
        }
        public List<OrcamentoResponse> ListarSolicitantes(int id, OrcamentoQuery query)
        {
            ExpressionStarter<Orcamento> filter = PredicateBuilder.New<Orcamento>(a => true);

            if (id > 0)
                filter.And(a => a.UsuarioSolicitanteId == id);


            filter.And(a => a.StatusOrcamento == query.status_orcamento);
            

            Type myType = typeof(Orcamento);

            var _retorno = _domain.Listar(filter);

            return _mapper.Map<List<OrcamentoResponse>>(_retorno);
        }



        public List<OrcamentoResponse> ListarOrcamento(int id)
        {
            ExpressionStarter<Orcamento> filter = PredicateBuilder.New<Orcamento>(a => true);

            if (id > 0)
                filter.And(a => a.Usuario.Id == id);

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
            UsuarioResponse _usuario = _usuarioService.Obter(request.usuario_solicitante_id);
            if (_usuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            UsuarioResponse _profissional = _usuarioService.Obter(request.usuario_id);
            if (_usuario == null)
            {
                throw new Exception("Profissional não encontrado");
            }

            _request.UsuarioId = _profissional.id;
            _request.UsuarioSolicitanteId = _usuario.id;
            _request = _domain.Salvar(_request);
            return _mapper.Map<OrcamentoResponse>(_request);
        }

        public OrcamentoResponse Alterar(int id, OrcamentoAlterarRequest request)
        {
            Orcamento orcamento = _domain.Obter(id);
            orcamento.StatusOrcamento = request.status_orcamento;
            orcamento = _domain.Alterar(orcamento);
            return _mapper.Map<OrcamentoResponse>(orcamento);
        }       
     
    }
}
