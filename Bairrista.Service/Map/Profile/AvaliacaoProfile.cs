using AutoMapper;
using Bairrista.Dominio;
using Bairrista.Service.Model;

namespace Bairrista.Service.Map
{
    public class AvaliacaoProfile : Profile
    {
        public AvaliacaoProfile()
        {
            CreateMap<Avaliacao, AvaliacaoResponse>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<AvaliacaoRequest, Avaliacao>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
