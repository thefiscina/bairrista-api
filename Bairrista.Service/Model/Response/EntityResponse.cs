using System;
using System.Text.Json.Serialization;

namespace Bairrista.Service.Model
{
    public class EntityResponse
    {
        [JsonIgnore]
        public int id { get; set; }
        //public string uuid { get; set; }
        //public DateTime cadastrado_em { get; set; }
        //public DateTime atualizado_em { get; set; }
    }
}