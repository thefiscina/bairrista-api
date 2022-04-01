using Bairrista.Dominio;
using Bairrista.Dominio.Service;
using Bairrista.Service.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstadoController : ControllerBase
    {
        private readonly ILogger<EstadoController> _logger;
        private readonly IEstadoService _service;
        private readonly IMunicipioService _serviceMunicipio;


        public EstadoController(ILogger<EstadoController> logger, IEstadoService service, IMunicipioService municipioService)
        {
            _logger = logger;
            _service = service;
            _serviceMunicipio = municipioService;

        }

        [HttpGet]
        public List<EstadoResponse> Listar([FromQuery] EstadoQuery query)
        {
            List<EstadoResponse> retorno = new List<EstadoResponse>();
            retorno = _service.Listar(query);
            return retorno;
        }

        [HttpGet("{id}/Municipio")]
        public List<MunicipioResponse> ListarMunicipios(int id)
        {            
            List<MunicipioResponse> retorno = new List<MunicipioResponse>();
            retorno = _serviceMunicipio.Listar(id);

            return retorno;
        }
    }
}