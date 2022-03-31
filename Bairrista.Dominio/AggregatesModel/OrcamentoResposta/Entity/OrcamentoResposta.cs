using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bairrista.Dominio
{

    public class OrcamentoResposta : Entity
    {      
        [Column("descricao")]
        public string Descricao { get; set; }
       
        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;     

        [Column("valor")]
        public double Valor { get; set; }

        [Column("orcamento_id")]
        [ForeignKey("Orcamento")]
        public int OrcamentoId { get; set; }
        public virtual Orcamento Orcamento { get; set; }     

    }    
}
