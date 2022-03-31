using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bairrista.Dominio
{

    public class Profissao : Entity
    {
        [Column("nome")]
        public string Nome { get; set; }
              
    }    
}
