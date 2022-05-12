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
    public class OrcamentoRespostaController : ControllerBase
    {
        private readonly ILogger<OrcamentoRespostaResponse> _logger;
        private readonly IOrcamentoRespostaService _service;

        public OrcamentoRespostaController(ILogger<OrcamentoRespostaResponse> logger, IOrcamentoRespostaService service)
        {
            _logger = logger;
            _service = service;
        }
    

        [HttpPost]
        public OrcamentoRespostaResponse Salvar([FromBody] OrcamentoRespostaRequest request)
        {
            return _service.Salvar(request);
        }
  

        [HttpGet("{id}")]
        public OrcamentoRespostaResponse Obter(int id)
        {
            return _service.Obter(id);
        }
    }
}