using AutoMapper;
using Bairrista.Service.Map;
using Bairrista.Service.Model;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bairrista.Dominio.Service
{
    public interface IMunicipioService
    {
        List<MunicipioResponse> Listar(MunicipioQuery query);
        MunicipioResponse Obter(int id);
        List<MunicipioResponse> Listar(int id);
    }

    public class MunicipioService : IMunicipioService
    {
        IMunicipioDomain _domain;
        IUsuarioService _usuarioService;
        IMapper _mapper;
        public MunicipioService(DashboardContext context, IUsuarioService usuarioService)
        {
            _mapper = AutoMapping.mapper;
            _domain = new MunicipioDomain(context);
            _usuarioService = usuarioService;
        }
        public List<MunicipioResponse> Listar(MunicipioQuery query)
        {
            ExpressionStarter<Municipio> filter = PredicateBuilder.New<Municipio>(a => true);

            if (query.estado_id > 0)
                filter.And(a => a.Estado.Id == query.estado_id);

            if (!String.IsNullOrEmpty(query.texto))
            {
                string texto = query.texto.ToLower();
                filter.And(a => a.Nome.ToLower().Contains(texto));
            }

            if (!String.IsNullOrEmpty(query.cep))
            {
                string texto = query.texto.ToLower();
                filter.And(a => a.Cep.ToLower().Contains(texto));
            }

            Type myType = typeof(Municipio);

            var _retorno = _domain.Listar(filter);

            return _mapper.Map<List<MunicipioResponse>>(_retorno);
        }

        public MunicipioResponse Obter(int id)
        {
            return _mapper.Map<MunicipioResponse>(_domain.Obter(id));
        }

        public List<MunicipioResponse> Listar(int id)
        {
            ExpressionStarter<Municipio> filter = PredicateBuilder.New<Municipio>(a => true);

            if (id > 0)
                filter.And(a => a.Estado.Id == id);
          
            Type myType = typeof(Municipio);

            var _retorno = _domain.Listar(filter);

            return _mapper.Map<List<MunicipioResponse>>(_retorno);
        }

    }
}
