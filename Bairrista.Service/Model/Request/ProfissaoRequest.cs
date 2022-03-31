using Bairrista.Dominio;

namespace Bairrista.Service.Model
{
    public class ProfissaoRequest
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