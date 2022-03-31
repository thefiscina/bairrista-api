using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bairrista.Dominio
{

    public class PagamentoUsuario : Entity
    {
 
        [Column("dados_pagamento")]
        public string DadosPagamento { get; set; }
       
        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;
     
        [Column("usuario_id")]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }       
    }    
}
