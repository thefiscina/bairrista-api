using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bairrista.Dominio
{

    public class Estado : Entity
    {
        [Column("nome")]
        public string Nome { get; set; }

        [Column("sigla")]
        public string Sigla { get; set; }
    }    
}
