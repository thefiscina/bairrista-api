using Bairrista.Dominio;

namespace Bairrista.Service.Model
{
    public class AuthResponse
    {
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string access_token { get; set; }
        public string profissao { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public UsuarioType tipo_usuario { get; set; }
        public int id { get; set; }


    }
}
