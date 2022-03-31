using AutoMapper;
using Bairrista.Dominio;
using Bairrista.Service.Model;

namespace Bairrista.Service.Map
{
    public class MunicipioProfile : Profile
    {
        public MunicipioProfile()
        {
            CreateMap<Municipio, MunicipioResponse>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<MunicipioRequest, Municipio>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
