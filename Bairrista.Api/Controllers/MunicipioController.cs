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
    public class MunicipioController : ControllerBase
    {
        private readonly ILogger<MunicipioController> _logger;
        private readonly IMunicipioService _service;

        public MunicipioController(ILogger<MunicipioController> logger, IMunicipioService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public List<MunicipioResponse> Listar([FromQuery] MunicipioQuery query)
        {
            List<MunicipioResponse> retorno = new List<MunicipioResponse>();
            retorno = _service.Listar(query);
            return retorno;
        }
    }
}