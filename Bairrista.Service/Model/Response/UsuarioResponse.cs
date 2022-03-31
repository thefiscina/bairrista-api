using System.Collections.Generic;

namespace Bairrista.Service.Model
{
    public class UsuarioResponse : EntityResponse
    {
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string cpf { get; set; }
        public int tipo_usuario { get; set; }
        public string profissao { get; set; }


    }
}
