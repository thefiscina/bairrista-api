using System.ComponentModel;

namespace Bairrista.Dominio
{
    public enum OrcamentoType
    {
        [Description("PENDENTE")]
        PENDENTE = 0,
        [Description("RECUSADO")]
        RECUSADO = 1,
        [Description("APROVADO")]
        APROVADO = 2,
        [Description("AGUARDANDO CLIENTE")]
        AGUARDANDO_CLIENTE = 3,
        [Description("RECUSADO PELO PROFISSIONAL")]
        RECUSADO_PROFISSIONAL = 4,
        [Description("FINALIZADO")]
        FINALIZADO = 5,
        [Description("AVALIADO")]
        AVALIADO = 6
    }
}
