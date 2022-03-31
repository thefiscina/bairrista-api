using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bairrista.Dominio
{

    public class Municipio : Entity
    {
        [Column("nome")]
        public string Nome { get; set; }

        [Column("cep")]
        public string Cep { get; set; }


        [Column("co_ibge")]
        public string CoIbeg { get; set; }

        [Column("estado_id")]
        [ForeignKey("Estado")]
        public int EstadoId { get; set; }
        public virtual Estado Estado { get; set; }
    }    
}
