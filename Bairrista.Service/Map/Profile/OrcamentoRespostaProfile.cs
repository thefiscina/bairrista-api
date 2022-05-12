using AutoMapper;
using Bairrista.Dominio;
using Bairrista.Service.Model;

namespace Bairrista.Service.Map
{
    public class OrcamentoRespostaProfile : Profile
    {
        public OrcamentoRespostaProfile()
        {
            CreateMap<OrcamentoResposta, OrcamentoRespostaResponse>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<OrcamentoRespostaRequest, OrcamentoResposta>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
