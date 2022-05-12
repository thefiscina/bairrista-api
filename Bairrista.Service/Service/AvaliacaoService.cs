using AutoMapper;
using Bairrista.Service.Map;
using Bairrista.Service.Model;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bairrista.Dominio.Service
{
    public interface IAvaliacaoService
    {
        List<AvaliacaoResponse> Listar(ComumQuery query);
        AvaliacaoResponse Obter(int id);
        AvaliacaoResponse Salvar(AvaliacaoRequest AvaliacaoService);

        List<AvaliacaoResponse> Listar(int id);                    
    }

    public class AvaliacaoService : IAvaliacaoService
    {
        IAvaliacaoDomain _domain;
        IUsuarioService _usuarioService;

        IMapper _mapper;
        public AvaliacaoService(DashboardContext context, IUsuarioService usuarioService)
        {
            _mapper = AutoMapping.mapper;
            _domain = new AvaliacaoDomain(context);
            _usuarioService = usuarioService;
        }
        public List<AvaliacaoResponse> Listar(ComumQuery query)
        {
            ExpressionStarter<Avaliacao> filter = PredicateBuilder.New<Avaliacao>(a => true);

            if (query.usuario_id > 0)
                filter.And(a => a.Usuario.Id == query.usuario_id);

            Type myType = typeof(Endereco);

            var _retorno = _domain.Listar(filter);

            return _mapper.Map<List<AvaliacaoResponse>>(_retorno);
        }



        public AvaliacaoResponse Obter(int id)
        {
            return _mapper.Map<AvaliacaoResponse>(_domain.Obter(id));
        }

        public AvaliacaoResponse Salvar(AvaliacaoRequest request)
        {
            Avaliacao _request = _mapper.Map<Avaliacao>(request);
            UsuarioResponse _usuario = _usuarioService.Obter(request.usuario_id);
            if (_usuario == null)
                throw new Exception("");

            _request.UsuarioId = _usuario.id;

            _request = _domain.Salvar(_request);
            return _mapper.Map<AvaliacaoResponse>(_request);
        }

        public List<AvaliacaoResponse> Listar(int id)
        {
            ExpressionStarter<Avaliacao> filter = PredicateBuilder.New<Avaliacao>(a => true);

            if (id > 0)
                filter.And(a => a.Usuario.Id == id);

            Type myType = typeof(Avaliacao);

            var _retorno = _domain.Listar(filter);

            return _mapper.Map<List<AvaliacaoResponse>>(_retorno);
        }


    }
}
