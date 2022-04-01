using AutoMapper;
using Bairrista.Service.Map;
using Bairrista.Service.Model;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bairrista.Dominio.Service
{
    public interface IProfissaoService
    {
        List<ProfissaoResponse> Listar(ProfissaoQuery query);
        ProfissaoResponse Obter(int id);
        //ProfissaoResponse Salvar(ProfissaoRequest ProfissaoService);
        //ProfissaoResponse Alterar(int id, ProfissaoRequest ProfissaoService);                
    }

    public class ProfissaoService : IProfissaoService
    {
        IProfissaoDomain _domain;
        IUsuarioService _usuarioService;
        IMapper _mapper;
        public ProfissaoService(DashboardContext context, IUsuarioService usuarioService)
        {
            _mapper = AutoMapping.mapper;
            _domain = new ProfissaoDomain(context);
            _usuarioService = usuarioService;
        }
        public List<ProfissaoResponse> Listar(ProfissaoQuery query)
        {
            ExpressionStarter<Profissao> filter = PredicateBuilder.New<Profissao>(a => true);

            if (!String.IsNullOrEmpty(query.texto))
            {
                string texto = query.texto.ToLower();
                filter.And(a => a.Nome.ToLower().Contains(texto));
            }

            Type myType = typeof(Profissao);
            var _retorno = _domain.Listar(filter);
            return _mapper.Map<List<ProfissaoResponse>>(_retorno);
        }



        public ProfissaoResponse Obter(int id)
        {
            return _mapper.Map<ProfissaoResponse>(_domain.Obter(id));
        }

        //public ProfissaoResponse Salvar(ProfissaoRequest request)
        //{
        //    Profissao _request = _mapper.Map<Profissao>(request);          
        //    _request = _domain.Salvar(_request);
        //    return _mapper.Map<ProfissaoResponse>(_request);
        //}

        //public ProfissaoResponse Alterar(int id, ProfissaoRequest request)
        //{
        //    Profissao _request = _mapper.Map<Profissao>(request);
        //    //_request.Uuid = new Guid(uuid);
        //    UsuarioResponse _usuario = _usuarioService.Obter(request.usuario_id);
        //    if (_usuario == null)
        //        throw new Exception("");

        //    _request.UsuarioId = _usuario.id;

        //    _request = _domain.Alterar(_request);
        //    return _mapper.Map<ProfissaoResponse>(_request);
        //}       

    }
}
