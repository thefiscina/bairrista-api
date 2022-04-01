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
    public class ProfissaoController : ControllerBase
    {
        private readonly ILogger<ProfissaoController> _logger;
        private readonly IProfissaoService _service;

        public ProfissaoController(ILogger<ProfissaoController> logger, IProfissaoService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public List<ProfissaoResponse> Listar([FromQuery] ProfissaoQuery query)
        {
            List<ProfissaoResponse> retorno = new List<ProfissaoResponse>();
            retorno = _service.Listar(query);
            return retorno;
        }

        //[HttpPost]
        //public EnderecoResponse Salvar([FromBody] EnderecoRequest EnderecoRequest)
        //{
        //    return _service.Salvar(EnderecoRequest);
        //}

        //[HttpPut("{id}")]
        //public EnderecoResponse Alterar(int id, [FromBody] EnderecoRequest EnderecoRequest)
        //{
        //    return _service.Alterar(id, EnderecoRequest);
        //}

        //[HttpGet("{id}")]
        //public EnderecoResponse Obter(int id)
        //{
        //    return _service.Obter(id);
        //}
    }
}