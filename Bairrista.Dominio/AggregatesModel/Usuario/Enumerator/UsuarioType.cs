using System.ComponentModel;

namespace Bairrista.Dominio
{
    public enum UsuarioType
    {
        [Description("COMUM")]
        COMUM = 0,
        [Description("PROFISSIONAL")]
        PROFISSIONAL = 1,
        [Description("ADMIN")]
        ADMIN = 2
    }
}
