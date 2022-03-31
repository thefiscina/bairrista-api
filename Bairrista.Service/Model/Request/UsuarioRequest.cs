using Bairrista.Dominio;
using System;

namespace Bairrista.Service.Model
{
    public class UsuarioRequest
    {
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string profissao { get; set; }
        public string senha { get; set; } 
        public string tipo_usuario { get; set; }

    }
}
