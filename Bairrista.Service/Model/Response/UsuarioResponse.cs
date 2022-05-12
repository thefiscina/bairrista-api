using Bairrista.Dominio;
using System.Collections.Generic;

namespace Bairrista.Service.Model
{
    public class UsuarioResponse 
    {
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string access_token { get; set; }
        public string profissao { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public UsuarioType tipo_usuario { get; set; }
        public int id { get; set; }
        public List<EnderecoResponse> enderecos { get; set; }
        public List<OrcamentoResponse> orcamentos { get; set; }
        public List<AvaliacaoResponse> avaliacoes { get; set; }



    }
}
