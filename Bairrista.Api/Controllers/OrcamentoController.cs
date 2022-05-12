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
    public class OrcamentoController : ControllerBase
    {
        private readonly ILogger<OrcamentoController> _logger;
        private readonly IOrcamentoService _service;
        private readonly IOrcamentoRespostaService _orcamentoUsuarioService;

        public OrcamentoController(ILogger<OrcamentoController> logger, IOrcamentoService service, IOrcamentoRespostaService orcamentoUsuarioService)
        {
            _logger = logger;
            _service = service;
            _orcamentoUsuarioService = orcamentoUsuarioService;

        }

        [HttpPost]
        public OrcamentoResponse Salvar([FromBody] OrcamentoRequest OrcamentoRequest)
        {
            return _service.Salvar(OrcamentoRequest);
        }


        [HttpGet("{id}")]
        public OrcamentoResponse Obter(int id)
        {
            return _service.Obter(id);
        }


        #region Respostas
        [HttpGet("{id}/Respostas")]
        public List<OrcamentoRespostaResponse> ListarRespostas(int id)
        {
            List<OrcamentoRespostaResponse> retorno = new List<OrcamentoRespostaResponse>();
            retorno = _orcamentoUsuarioService.Listar(id);

            return retorno;
        }
        #endregion

        [HttpPut("{id}")]
        public OrcamentoResponse Alterar(int id, [FromBody] OrcamentoAlterarRequest bodyRequest)
        {
            return _service.Alterar(id, bodyRequest);
        }
    }
}