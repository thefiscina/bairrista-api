using Bairrista.Dominio;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bairrista.Service.Model
{
    public class OrcamentoRespostaResponse : EntityResponse
    {
        public string descricao { get; set; }
        public double valor { get; set; }
    }
}