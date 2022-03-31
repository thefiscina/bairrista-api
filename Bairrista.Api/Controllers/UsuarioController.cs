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



        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioService service, IEnderecoService _enderecoService)
        {
            _logger = logger;
            _service = service;
            _enderecoUsuarioService = _enderecoService;          
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


        [HttpPut("{id}")]
        public UsuarioResponse Alterar(int id, [FromBody] UsuarioRequest bodyRequest)
        {
            return _service.Alterar(id, bodyRequest);
        }

        #region Endereco
        [HttpGet("{id}/Endereco")]
        public List<EnderecoResponse> ListarEnderecos(int id, [FromQuery] EnderecoQuery query)
        {
            query.usuario_id = id;
            List<EnderecoResponse> retorno = new List<EnderecoResponse>();            
            retorno = _enderecoUsuarioService.Listar(query);
          
            return retorno;
        }

        [HttpPost("{id}/Endereco")]
        public EnderecoResponse SalvarEndereco(int id, [FromBody] EnderecoRequest EnderecoRequest)
        {
            EnderecoRequest.usuario_id = id;
            return _enderecoUsuarioService.Salvar(EnderecoRequest);
        }
        #endregion


    }
}