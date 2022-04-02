using Bairrista.Dominio;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bairrista.Service.Model
{
    public class MunicipioResponse 
    {
        public int id { get; set; }
        public string nome { get; set; }                
    }
}