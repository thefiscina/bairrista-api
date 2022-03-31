using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bairrista.Dominio
{

    public class Avaliacao : Entity
    {
        [Column("texto")]
        public string Texto { get; set; }
       
        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [Column("usuario_id")]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }       

    }    
}
