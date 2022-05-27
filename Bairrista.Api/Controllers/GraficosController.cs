using Bairrista.Dominio.Service;
using Bairrista.Service.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GraficosController : ControllerBase
    {
        private readonly ILogger<GraficosController> _logger;
        private readonly IUsuarioService _service;    
        private readonly IEnderecoService _enderecoUsuarioService;
        private readonly IOrcamentoService _orcamentoUsuarioService;
        private readonly IAvaliacaoService _avaliacaoUsuarioService;




        public GraficosController(ILogger<GraficosController> logger, IUsuarioService service, IEnderecoService _enderecoService, IOrcamentoService _orcamentoService, IAvaliacaoService _avaliacaoService)
        {
            _logger = logger;
            _service = service;
            _enderecoUsuarioService = _enderecoService;
            _orcamentoUsuarioService = _orcamentoService;
            _avaliacaoUsuarioService = _avaliacaoService;

        }

        #region Orcamentos      
        [HttpGet("{id}/OrcamentoSolicitados")]
        public List<OrcamentoResponse> ListarOrcamentos(int id, [FromQuery] OrcamentoQuery query)
        {
            List<OrcamentoResponse> retorno = new List<OrcamentoResponse>();
            retorno = _orcamentoUsuarioService.Listar(id, query);
            return retorno;
        }

        [HttpGet("{id}/OrcamentoRecebidos")]
        public List<OrcamentoResponse> ListarOrcamentosSolicitante(int id, [FromQuery] OrcamentoQuery query)
        {
            List<OrcamentoResponse> retorno = new List<OrcamentoResponse>();
            retorno = _orcamentoUsuarioService.ListarSolicitantes(id, query);

            return retorno;
        }

        #endregion

        #region Avaliacoes      
        [HttpGet("{id}/AvaliacaoRecebida")]
        public List<AvaliacaoResponse> ListarAvaliacoes(int id)
        {
            List<AvaliacaoResponse> retorno = new List<AvaliacaoResponse>();
            retorno = _avaliacaoUsuarioService.Listar(id);

            return retorno;
        }
        #endregion

    }
}