using AutoMapper;
using Bairrista.Dominio;
using Bairrista.Service.Model;

namespace Bairrista.Service.Map
{
    public class EstadoProfile : Profile
    {
        public EstadoProfile()
        {
            CreateMap<Estado, EstadoResponse>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<EstadoRequest, Estado>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
