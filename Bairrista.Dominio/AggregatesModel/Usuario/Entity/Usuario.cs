using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bairrista.Dominio
{
    public class Usuario : Entity
    {
        [Column("nome")]
        public string Nome { get; set; }
        [Column("sobrenome")]
        public string Sobrenome { get; set; }
        [Column("cpf")]
        public string Cpf { get; set; }

        [NotMapped]
        public string Token { get; set; } = "";

        [Column("senha")]
        public string Senha { get; set; }

        [Column("profissao")]
        public string Profissao { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("telefone")]
        public string Telefone { get; set; }

        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        
        [Column("tipo_usuario")]
        public UsuarioType TipoUsuario { get; set; } = UsuarioType.COMUM;

        [Column("usuario_destaque")]
        public Boolean UsuarioDestaque { get; set; } = false;
        
        public List<Endereco> Enderecos { get; set; }

        public List<Orcamento> Orcamentos { get; set; }

        public List<Avaliacao> Avaliacoes { get; set; }


    }
}
