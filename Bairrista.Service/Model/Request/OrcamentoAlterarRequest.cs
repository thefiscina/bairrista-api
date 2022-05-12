using Bairrista.Dominio;
using System;

namespace Bairrista.Service.Model
{
    public class OrcamentoAlterarRequest
    {
        public OrcamentoType status_orcamento { get; set; } = OrcamentoType.PENDENTE;
    }
}