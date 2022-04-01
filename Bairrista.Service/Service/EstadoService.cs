using AutoMapper;
using Bairrista.Service.Map;
using Bairrista.Service.Model;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bairrista.Dominio.Service
{
    public interface IEstadoService
    {
        List<EstadoResponse> Listar(EstadoQuery query);
        EstadoResponse Obter(int id);          
    }

    public class EstadoService : IEstadoService
    {
        IEstadoDomain _domain;        
        IUsuarioService _usuarioService;        
        IMapper _mapper;
        public EstadoService(DashboardContext context, IUsuarioService usuarioService)
        {
            _mapper = AutoMapping.mapper;
            _domain = new EstadoDomain(context);
            _usuarioService = usuarioService;            
        }
        public List<EstadoResponse> Listar(EstadoQuery query)
        {
            ExpressionStarter<Estado> filter = PredicateBuilder.New<Estado>(a => true);

            if (!String.IsNullOrEmpty(query.texto))
            {
                string texto = query.texto.ToLower();
                filter.And(a => a.Nome.ToLower().Contains(texto));
            }

            Type myType = typeof(Estado);
       
            var _retorno = _domain.Listar(filter);          

            return _mapper.Map<List<EstadoResponse>>(_retorno);
        }



        public EstadoResponse Obter(int id)
        {
            return _mapper.Map<EstadoResponse>(_domain.Obter(id));
        }

     
    }
}
