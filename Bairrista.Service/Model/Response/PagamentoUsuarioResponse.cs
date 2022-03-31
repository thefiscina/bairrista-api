using Bairrista.Dominio;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bairrista.Service.Model
{
    public class PagamentoUsuarioResponse : EntityResponse
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int usuario_id { get; set; }
    }
}