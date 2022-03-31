using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bairrista.Dominio
{
    public class Entity
    {        
        [Key]
        [Column("id")]
        public int Id { get; set; }
        //[Column("uuid")]
        //public Guid Uuid { get; set; } = Guid.NewGuid();
        //[Column("cadastrado_em")]
        //public DateTime CadastradoEm { get; set; } = DateTime.Now;
        //[Column("atualizado_em")]
        //public DateTime AtualizadoEm { get; set; } = DateTime.Now;

    }
}
