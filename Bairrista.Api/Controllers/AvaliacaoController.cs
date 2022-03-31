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
    public class AvaliacaoController : ControllerBase
    {
        private readonly ILogger<AvaliacaoController> _logger;
        private readonly IAvaliacaoService _service;

        public AvaliacaoController(ILogger<AvaliacaoController> logger, IAvaliacaoService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public List<AvaliacaoResponse> Listar([FromQuery] ComumQuery query)
        {
            List<AvaliacaoResponse> retorno = new List<AvaliacaoResponse>();
            retorno = _service.Listar(query);
            return retorno;
        }

        [HttpPost]
        public AvaliacaoResponse Salvar([FromBody] AvaliacaoRequest AvaliacaoRequest)
        {
            return _service.Salvar(AvaliacaoRequest);
        }      

        [HttpGet("{id}")]
        public AvaliacaoResponse Obter(int id)
        {
            return _service.Obter(id);
        }
    }
}