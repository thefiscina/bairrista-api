using Bairrista.Dominio;
using System;

namespace Bairrista.Service.Model
{
    public class AvaliacaoRequest
    {
        public string texto { get; set; }
        public DateTime data_criacao { get; set; }
        public int usuario_id { get; set; }       
    }
}