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
        APROVADO = 2
    }
}
