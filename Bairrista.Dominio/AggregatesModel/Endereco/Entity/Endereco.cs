using System.ComponentModel.DataAnnotations.Schema;

namespace Bairrista.Dominio
{

    public class Endereco : Entity
    {
        [Column("cep")]
        public string Cep { get; set; }

        [Column("logradouro")]
        public string Logradouro { get; set; }

        [Column("bairro")]
        public string Bairro { get; set; }

        [Column("estado")]
        public string Estado { get; set; }

        [Column("cidade")]
        public string Cidade { get; set; }

        [Column("latitude")]
        public decimal? Latitude { get; set; }

        [Column("longitude")]
        public decimal? Longitude { get; set; }

        [Column("endereco_principal")]
        public bool EnderecoPrincipal { get; set; } = false;

        [Column("estado_id")]
        public int? EstadoId { get; set; }

        [Column("cidade_id")]
        public int? CidadeId { get; set; }


        [Column("usuario_id")]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }       

    }    
}
