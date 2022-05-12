using Bairrista.Dominio;
using System;

namespace Bairrista.Service.Model
{
    public class UsuarioOrcamentoRequest
    {
        public OrcamentoType status_orcamento { get; set; } = OrcamentoType.PENDENTE;

    }
}