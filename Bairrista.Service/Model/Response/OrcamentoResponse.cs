using Bairrista.Dominio;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bairrista.Service.Model
{
    public class OrcamentoResponse
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public DateTime data_hora_orcamento { get; set; }
        public DateTime data_criacao { get; set; }
        public int usuario_solicitante_id { get; set; }
        public int UsuarioId { get; set; }
        public OrcamentoType status_orcamento { get; set; }

        public List<OrcamentoRespostaResponse> Respostas { get; set; }

    }
}