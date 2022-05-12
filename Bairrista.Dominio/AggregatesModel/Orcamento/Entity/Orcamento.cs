using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bairrista.Dominio
{

    public class Orcamento : Entity
    {
        [Column("status_orcamento")]
        public OrcamentoType StatusOrcamento { get; set; } = OrcamentoType.PENDENTE;

        [Column("descricao")]
        public string Descricao { get; set; }
       
        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [Column("data_hora_orcamento")]
        public DateTime DataHoraOrcamento { get; set; } = DateTime.Now;

        [Column("usuario_solicitante_id")]
        public int UsuarioSolicitanteId { get; set; }

        [Column("usuario_id")]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [Column("endereco_id")]
        [ForeignKey("Endereco")]
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }

        public List<OrcamentoResposta> Respostas { get; set; }

    }    
}
