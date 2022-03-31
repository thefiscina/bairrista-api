using Bairrista.Dominio;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bairrista.Service.Model
{
    public class AvaliacaoResponse : EntityResponse
    {
        public string texto { get; set; }
        public DateTime data_criacao { get; set; }     
        public int usuario_id { get; set; }
    }
}