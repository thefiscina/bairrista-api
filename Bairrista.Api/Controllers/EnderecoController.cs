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
    public class EnderecoController : ControllerBase
    {
        private readonly ILogger<EnderecoController> _logger;
        private readonly IEnderecoService _service;

        public EnderecoController(ILogger<EnderecoController> logger, IEnderecoService service)
        {
            _logger = logger;
            _service = service;
        }

        //[HttpGet]
        //public List<EnderecoResponse> Listar([FromQuery] EnderecoQuery query)
        //{
        //    List<EnderecoResponse> retorno = new List<EnderecoResponse>();
        //    retorno = _service.Listar(query);
        //    return retorno;
        //}

        //[HttpPost]
        //public EnderecoResponse Salvar([FromBody] EnderecoRequest EnderecoRequest)
        //{
        //    return _service.Salvar(EnderecoRequest);
        //}

        [HttpPut("{id}")]
        public EnderecoResponse Alterar(int id, [FromBody] EnderecoRequest EnderecoRequest)
        {
            return _service.Alterar(id, EnderecoRequest);
        }

        //[HttpGet("{id}")]
        //public EnderecoResponse Obter(int id)
        //{
        //    return _service.Obter(id);
        //}
    }
}