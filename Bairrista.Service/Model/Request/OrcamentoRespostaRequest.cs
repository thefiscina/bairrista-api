using Bairrista.Dominio;

namespace Bairrista.Service.Model
{
    public class OrcamentoRespostaRequest
    {
        public string descricao { get; set; }
        public int orcamento_id { get; set; }
        public double valor { get; set; }
    }
}