using Bairrista.Dominio;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bairrista.Service.Model
{
    public class MunicipioResponse : EntityResponse
    {
        public string nome { get; set; }
        public string cep { get; set; }
      
        public int estado_id { get; set; }
    }
}