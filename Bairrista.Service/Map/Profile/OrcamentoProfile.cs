using AutoMapper;
using Bairrista.Dominio;
using Bairrista.Service.Model;

namespace Bairrista.Service.Map
{
    public class OrcamentoProfile : Profile
    {
        public OrcamentoProfile()
        {
            CreateMap<Orcamento, OrcamentoResponse>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<OrcamentoRequest, Orcamento>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
