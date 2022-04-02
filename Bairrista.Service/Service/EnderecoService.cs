using AutoMapper;
using Bairrista.Service.Map;
using Bairrista.Service.Model;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bairrista.Dominio.Service
{
    public interface IEnderecoService
    {
        List<EnderecoResponse> Listar(EnderecoQuery query);
        EnderecoResponse Obter(int id);
        EnderecoResponse Salvar(EnderecoRequest EnderecoService);
        EnderecoResponse Alterar(int id, EnderecoRequest EnderecoService);

        List<EnderecoResponse> Listar(int id);

    }

    public class EnderecoService : IEnderecoService
    {
        IEnderecoDomain _domain;        
        IUsuarioService _usuarioService;        
        IMapper _mapper;
        public EnderecoService(DashboardContext context, IUsuarioService usuarioService)
        {
            _mapper = AutoMapping.mapper;
            _domain = new EnderecoDomain(context);
            _usuarioService = usuarioService;            
        }
        public List<EnderecoResponse> Listar(EnderecoQuery query)
        {
            ExpressionStarter<Endereco> filter = PredicateBuilder.New<Endereco>(a => true);

            if (query.usuario_id > 0)
                filter.And(a => a.Usuario.Id == query.usuario_id);

            if (query.principal)
                filter.And(a => a.EnderecoPrincipal == query.principal);

            Type myType = typeof(Endereco);
       
            var _retorno = _domain.Listar(filter);          

            return _mapper.Map<List<EnderecoResponse>>(_retorno);
        }

        public List<EnderecoResponse> Listar(int id)
        {
            ExpressionStarter<Endereco> filter = PredicateBuilder.New<Endereco>(a => true);

            if (id > 0)
                filter.And(a => a.Usuario.Id == id);          

            Type myType = typeof(Endereco);

            var _retorno = _domain.Listar(filter);

            return _mapper.Map<List<EnderecoResponse>>(_retorno);
        }


        public EnderecoResponse Obter(int id)
        {
            return _mapper.Map<EnderecoResponse>(_domain.Obter(id));
        }

        public EnderecoResponse Salvar(EnderecoRequest request)
        {
            Endereco _request = _mapper.Map<Endereco>(request);
            UsuarioResponse _usuario = _usuarioService.Obter(request.usuario_id);
            if (_usuario == null)
                throw new Exception("");

            _request.UsuarioId = _usuario.id;

            _request = _domain.Salvar(_request);
            return _mapper.Map<EnderecoResponse>(_request);
        }

        public EnderecoResponse Alterar(int id, EnderecoRequest request)
        {
            Endereco _request = _mapper.Map<Endereco>(request);
            //_request.Uuid = new Guid(uuid);
            UsuarioResponse _usuario = _usuarioService.Obter(request.usuario_id);
            if (_usuario == null)
                throw new Exception("");

            _request.UsuarioId = _usuario.id;

            _request = _domain.Alterar(_request, id);
            return _mapper.Map<EnderecoResponse>(_request);
        }

    }
}
