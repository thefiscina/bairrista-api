using Bairrista.Dominio;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bairrista.Service.Model
{
    public class EstadoResponse
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sigla { get; set; }   
    }
}