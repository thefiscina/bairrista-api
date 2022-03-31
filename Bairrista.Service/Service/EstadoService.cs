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
        List<EstadoResponse> Listar();
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
        public List<EstadoResponse> Listar()
        {
            ExpressionStarter<Estado> filter = PredicateBuilder.New<Estado>(a => true);

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
