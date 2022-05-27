using Bairrista.Dominio.Service;
using Bairrista.Service.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioService _service;    
        private readonly IEnderecoService _enderecoUsuarioService;
        private readonly IOrcamentoService _orcamentoUsuarioService;
        private readonly IAvaliacaoService _avaliacaoUsuarioService;




        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioService service, IEnderecoService _enderecoService, IOrcamentoService _orcamentoService, IAvaliacaoService _avaliacaoService)
        {
            _logger = logger;
            _service = service;
            _enderecoUsuarioService = _enderecoService;
            _orcamentoUsuarioService = _orcamentoService;
            _avaliacaoUsuarioService = _avaliacaoService;

        }

        [HttpGet]
        public List<UsuarioResponse> Listar([FromQuery] UsuarioQuery query)
        {
            List<UsuarioResponse> retorno = new List<UsuarioResponse>();           
            retorno = _service.Listar(query);            
            return retorno;
        }


        [HttpGet("{id}")]
        public UsuarioResponse Obter(int id)
        {
            return _service.Obter(id);
        }

        [HttpPost]
        public UsuarioResponse Salvar([FromBody] UsuarioRequest usuarioRequest)
        {
            return _service.Salvar(usuarioRequest);
        }

        [HttpPost("Google")]
        public UsuarioResponse SalvarSocial([FromBody] UsuarioRequest usuarioRequest)
        {
            return _service.SalvarSocial(usuarioRequest);
        }


        [HttpPut("{id}")]
        public UsuarioResponse Alterar(int id, [FromBody] UsuarioRequest bodyRequest)
        {
            return _service.Alterar(id, bodyRequest);
        }

        [HttpGet("Profissionais")]
        public List<UsuarioResponse> ListarProfissionais([FromQuery] UsuarioQuery query)
        {
            List<UsuarioResponse> retorno = new List<UsuarioResponse>();
            retorno = _service.ListarProfissionais(query);
            return retorno;
        }

        #region Endereco
        [HttpGet("{id}/Endereco")]
        public List<EnderecoResponse> ListarEnderecos(int id)
        {            
            List<EnderecoResponse> retorno = new List<EnderecoResponse>();            
            retorno = _enderecoUsuarioService.Listar(id);
          
            return retorno;
        }

        [HttpPost("{id}/Endereco")]
        public EnderecoResponse SalvarEndereco(int id, [FromBody] EnderecoRequest EnderecoRequest)
        {
            EnderecoRequest.usuario_id = id;
            return _enderecoUsuarioService.Salvar(EnderecoRequest);
        }

        #endregion

        #region Orcamentos      
        [HttpGet("{id}/Orcamento")]
        public List<OrcamentoResponse> ListarOrcamentos(int id, [FromQuery] OrcamentoQuery query)
        {
            List<OrcamentoResponse> retorno = new List<OrcamentoResponse>();
            retorno = _orcamentoUsuarioService.Listar(id, query);

            return retorno;
        }

        [HttpGet("{id}/OrcamentoSolicitante")]
        public List<OrcamentoResponse> ListarOrcamentosSolicitante(int id, [FromQuery] OrcamentoQuery query)
        {
            List<OrcamentoResponse> retorno = new List<OrcamentoResponse>();
            retorno = _orcamentoUsuarioService.ListarSolicitantes(id, query);

            return retorno;
        }

        #endregion

        #region Avaliacoes      
        [HttpGet("{id}/Avaliacao")]
        public List<AvaliacaoResponse> ListarAvaliacoes(int id)
        {
            List<AvaliacaoResponse> retorno = new List<AvaliacaoResponse>();
            retorno = _avaliacaoUsuarioService.Listar(id);

            return retorno;
        }
        #endregion

    }
}