using Bairrista.Dominio;
using System;

namespace Bairrista.Service.Model
{
    public class OrcamentoRequest
    {
        public string descricao { get; set; }
        public DateTime data_hora_orcamento { get; set; }
        public int usuario_solicitante_id { get; set; }
        public int usuario_id { get; set; }
        public int endereco_id { get; set; }
      
    }
}