﻿using Bairrista.Dominio;
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

        public OrcamentoController(ILogger<OrcamentoController> logger, IOrcamentoService service)
        {
            _logger = logger;
            _service = service;
        }

        //[HttpGet]
        //public List<OrcamentoResponse> Listar([FromQuery] OrcamentoQuery query)
        //{
        //    List<OrcamentoResponse> retorno = new List<OrcamentoResponse>();
        //    retorno = _service.Listar(query);
        //    return retorno;
        //}

        [HttpPost]
        public OrcamentoResponse Salvar([FromBody] OrcamentoRequest OrcamentoRequest)
        {
            return _service.Salvar(OrcamentoRequest);
        }

        //[HttpPut("{id}")]
        //public OrcamentoResponse Alterar(int id, [FromBody] OrcamentoRequest OrcamentoRequest)
        //{
        //    return _service.Alterar(id, OrcamentoRequest);
        //}

        [HttpGet("{id}")]
        public OrcamentoResponse Obter(int id)
        {
            return _service.Obter(id);
        }
    }
}